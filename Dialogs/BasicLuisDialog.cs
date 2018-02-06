using System;
using System.Configuration;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace Microsoft.Bot.Sample.LuisBot
{
    // For more information about this template visit http://aka.ms/azurebots-csharp-luis
    [Serializable]
    public class BasicLuisDialog : LuisDialog<object>
    {
        public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(
            ConfigurationManager.AppSettings["LuisAppId"],
            ConfigurationManager.AppSettings["LuisAPIKey"],
            domain: ConfigurationManager.AppSettings["LuisAPIHostName"])))
        {
        }

        [LuisIntent("None")]
        public async Task NoneIntent(IDialogContext context, LuisResult result)
        {
            await this.ShowLuisResult(context, result);
        }

        // Go to https://luis.ai and create a new intent, then train/publish your luis app.
        // Finally replace "Gretting" with the name of your newly created intent in the following handler
        [LuisIntent("Greeting")]
        public async Task GreetingIntent(IDialogContext context, LuisResult result)
        {
            await this.ShowLuisResult(context, result);
        }

        [LuisIntent("Cancel")]
        public async Task CancelIntent(IDialogContext context, LuisResult result)
        {
            await this.ShowLuisResult(context, result);
        }

        [LuisIntent("Help")]
        public async Task HelpIntent(IDialogContext context, LuisResult result)
        {
            await this.ShowLuisResult(context, result);
        }

        /// <summary>
        /// Intent for retrieving an entry from the database
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [LuisIntent("GetPost")]
        public async Task GetPostIntent(IDialogContext context, LuisResult result)
        {
            //string message = $"This is where the database query will take place.";
            //string connetionString = Environment.GetEnvironmentVariable("MyDB");
            //await context.PostAsync($"Connection string: {connetionString}");
            //try
            //{
            //    using (SqlConnection connection = new SqlConnection(connetionString))
            //    {
            //        connection.Open();
            //        connection.Close();
            //        //using (SqlCommand command = CreateSqlCommand()
            //        //{
            //        //}
            //    }
            //}
            //catch (SqlException ex)
            //{
            //    await context.PostAsync($"Conn Error: {ex.Message}");
            //    //do something
            //}

            //var db = new DatabaseController();
            //message = db.GetQueryResult("");

            await this.DisplayAllLuisResults(context, result);
            //await this.ShowLuisResult(context, result);
        }

        /// <summary>
        /// detailed display of json view
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private async Task DisplayAllLuisResults(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Top Scoring Intent: {result.TopScoringIntent.Intent}" +
                                    $"\nScore: {result.TopScoringIntent.Score}");

            foreach (var entity in result.Entities)
            {
                await context.PostAsync($"\nEntity: {entity.Entity} " +
                                        $"\nType: {entity.Type}" +
                                        $"\nStartIndex: {entity.StartIndex}" +
                                        $"\nEndIndex: {entity.EndIndex}");
            }

            context.Wait(MessageReceived);
        }

        private async Task ShowLuisResult(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"You have reached {result.Intents[0].Intent}. You said: {result.Query}");

            context.Wait(MessageReceived);
        }
    }
}