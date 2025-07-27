# Day 07 - REST API Testing with RestSharp
**Goal:Use RestSharp to test REST APIs with NUnit framework.**
**Tasks:**  
- Set up RestSharp and NUnit project.
- Create GET, POST requests to Restful Booker.
- Validate response codes and content.

## 📦 NuGet Packages
```bash
dotnet add package RestSharp
```

## ✅ API Endpoints Used
- `GET /ping` – check server health
- `POST /booking` – create new booking
- `GET /booking/{id}` – retrieve a booking

---

## 📋 **✅ RESTSharp Cheat Sheet (NUnit Testing)**

| Action           | Code Example |
|------------------|--------------|
| Create Client    | `var client = new RestClient("https://url");` |
| Create Request   | `var request = new RestRequest("/endpoint", Method.Get);` |
| Add JSON Body    | `request.AddJsonBody(myObject);` |
| Execute Request  | `var response = client.Execute(request);` |
| Status Code Check| `Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);` |
| Response Content | `response.Content` |

---