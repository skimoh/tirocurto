//***CODE BEHIND - BY RODOLFO.FONSECA***//
//https://github.com/thatbrainiac/Tuya.Net

using System.Net;
using System.Text;
using Tuya.Net.Data.Settings;
using Tuya.Net;
using Tuya.Net.Data;

#region confidencial

var client_id = "xx";
var device_id = "xx";
var secret = "xx";

#endregion

Console.WriteLine("IOT Opacidade da Persiana");

Console.WriteLine("1 - 10%");
Console.WriteLine("2 - 50%");
Console.WriteLine("3 - 100%");

var key = Console.ReadKey();

if (key.Key == ConsoleKey.NumPad1)
{
    EnviarComando(true);
    Thread.Sleep(5000);
    EnviarComando(false);
}
if (key.Key == ConsoleKey.NumPad2)
{
    EnviarComando(true);
    Thread.Sleep(10000);
    EnviarComando(false);
}

if (key.Key == ConsoleKey.NumPad2)
{
    EnviarComando(true);
    Thread.Sleep(15000);
    EnviarComando(false);
}


Console.Read();


async void EnviarComando(bool ligar)
{    
    try
    {
        var client = TuyaClient.GetBuilder()
        .UsingDataCenter(DataCenter.WestUs)
        .UsingClientId(client_id) // replace with your actual client id
        .UsingSecret(secret) // replace with your actual client secret    
        .Build();

        //var device = await client.DeviceManager.GetDeviceAsync(device_id);
        //var status = device?.StatusList?.FirstOrDefault(ds => ds.Code == "switch_off");
        //if (status?.Value is not bool)
        //{
        //    throw new Exception("Cannot obtain the value of the device status, the switch_led status did not return bool as expected.");
        //}

        //// Get the device status (true if the light is turned on, false otherwise)
        //var isTurnedOn = (bool)status.Value!;

        // Create the command to send an instruction to maniuplate the light status
        var command = new Command()
        {
            Code = "switch_1",
            Value = true
        };

        // Send the command and obtain the result from the server.
        var result = await client.DeviceManager.SendCommandAsync(device_id, command); // returns true if the command was executed successfully, false otherwise.
    }
    catch (Exception ex)
    {
        Console.Write(ex.Message);        
    }
}
