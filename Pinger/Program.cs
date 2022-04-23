// Pinging microsoft.com

using Pinger;

Console.WriteLine("Who would you like to ping to?");
string host=Console.ReadLine(); 

Console.WriteLine("What message would you like to ping?");
string message=Console.ReadLine(); 

PingService pinger = new PingService(message);
pinger.sendPing(host);


