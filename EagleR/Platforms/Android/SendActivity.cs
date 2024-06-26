using Android.App;
using Android.Content;
using Android.OS;
using Azure.Storage.Queues;
using System.Text.Json;

namespace EagleR;

[Activity(Label = "EagleR", Exported = true)]
[IntentFilter([Intent.ActionSend], Categories = [Intent.CategoryDefault], DataMimeType = "text/plain")]
public sealed class SendActivity : Activity
{
    private static string StorageAccountConnectionString = "";

    public static void Initialize(string storageAccountConnectionString)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(storageAccountConnectionString);

        StorageAccountConnectionString = storageAccountConnectionString;
    }

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(StorageAccountConnectionString);

        base.OnCreate(savedInstanceState);

        Intent intent = Intent!;

        Task
            .Delay(TimeSpan.FromSeconds(0.5))
            .GetAwaiter()
            .OnCompleted(async () =>
            {
                switch (intent.Action)
                {
                    case Intent.ActionSend:
                        var link = intent.GetStringExtra(Intent.ExtraText);
                        var queueClient = new QueueClient(StorageAccountConnectionString, "eagle-saver");
                        await queueClient.SendMessageAsync(JsonSerializer.Serialize(new { Url = link }));
                        break;
                }
            });

        Finish();
    }
}
