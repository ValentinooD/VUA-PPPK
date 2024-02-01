using MongoDB.Bson;
using MongoDB.Driver;

namespace Task05
{
    internal static class Program
    {
        private const string DB_NAME = "task05";

        [STAThread]
        static void Main()
        {
            var connectionUri = "mongodb+srv://user:4LQjXBJdcu8odyKV@cluster0.beqydeb.mongodb.net/?retryWrites=true&w=majority";
            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            IMongoClient client;

            try
            {
                client = new MongoClient(settings);

                var result = client.GetDatabase("task05").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
            }
            catch (Exception e)
            {
                MessageBox.Show("There was a problem connecting to your " +
                    "Atlas cluster. Check that the URI includes a valid " +
                    "username and password, and that your IP address is " +
                    $"in the Access List.\n\nMessage: {e.Message}");
                return;
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(client, client.GetDatabase(DB_NAME)));
        }
    }
}