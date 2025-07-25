using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental._02_DataTypes.Events
{
   public class Video
   {
        public string Title { get; set; }
   }

    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }


    public class VideoEncoder
    {
        //1- Define a delegate
        //2- Define an event based on that delegates
        //3- Raise the event

        //public delegate void VideoEncodedEventHandler(object source, VideoEventArgs eargs);

        //EventHandler
        //EventHandler<TEventArgs>

        //public event VideoEncodedEventHandler VideoEncoded;
        public event EventHandler<VideoEventArgs> VideoEncoded;



        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video...");
            Thread.Sleep(3000);
            OnVideoEncoded(video);
        }

        public void OnVideoEncoded(Video video)
        {
            if(VideoEncoded != null)
            {
                VideoEncoded(this, new VideoEventArgs() { Video = video});
            }
        }
    }

    public class MailService
    {
        public void OnVideoEncoded(object source, VideoEventArgs args)
        {
            Console.WriteLine("Mail Service: Sending an email..." + args.Video.Title);
        }
    }

    public class MessageService
    {
        public void OnVideoEncded(object source, VideoEventArgs args)
        {
            Console.WriteLine("Messaging Service: sending a text message..." + args.Video.Title );
        }
    }

    [TestFixture]
    public class VideoEncoderEventTest
    {
        [Test]
        public void VideoEncoderTest()
        {
            var video = new Video () { Title = "Video 1"};

            VideoEncoder videoEncoder = new VideoEncoder();//publisher

            var mailService = new MailService(); //subscriber
            var messageService = new MessageService();

            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += messageService.OnVideoEncded;

            videoEncoder.Encode(video);

        }


    }

}
