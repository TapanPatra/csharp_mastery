using System.Runtime.InteropServices;
using System.Text;
using MQTTnet;
using MQTTnet.LowLevelClient;
using NBomber.Contracts;
using NBomber.CSharp;

namespace Day08_LoadTesting_Nbomber_Test
{

    public class MqttHivemqLoadTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SimpleMqttTest()
        {
            var scenario = Scenario.Create("mqtt_hivemqtt_scenario", async context =>
            {
                using var mqttClient = new MqttClientFactory().CreateMqttClient();
                string topic = "test/nbomber";         // Public test topic
                string payload = "Hello MQTT!";        // Message content


                var connect = await Step.Run("connect", context, async () =>
                {
                    var options = new MqttClientOptionsBuilder()
                    .WithTcpServer("\"broker.hivemq.com\", 1883") // HiveMQ public broker
                    .WithClientId(context.ScenarioInfo.InstanceId)
                    .Build();

                    var result = await mqttClient.ConnectAsync(options);


                    return Response.Ok();

                });


                var subscribe = await Step.Run("subscribe", context, async () =>
                {
                    await mqttClient.SubscribeAsync(topic);
                    return Response.Ok();
                });


                var publish = await Step.Run("publish", context, async () =>
                {
                    var message = new MqttApplicationMessageBuilder()
                        .WithTopic(topic)
                        .WithPayload(Encoding.UTF8.GetBytes(payload))
                        .Build();

                    var response = await mqttClient.PublishAsync(message);
                    return Response.Ok();
                });


                var receive = await Step.Run("receive", context, async () =>
                {
                    mqttClient.ApplicationMessageReceivedAsync += e =>
                    {
                        var receivedPayload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                        Console.WriteLine($"Received: {receivedPayload}");
                        return Task.CompletedTask;

                    };

                    return Response.Ok();

                });


                var disconnect = await Step.Run("disconnect", context, async () =>
                {
                    await mqttClient.DisconnectAsync();
                    return Response.Ok();
                });

                return Response.Ok();
            });



            NBomberRunner
            .RegisterScenarios(scenario)
            .Run();




        }
    }
}
