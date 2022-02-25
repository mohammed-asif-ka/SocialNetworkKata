using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SocialNetworkKata.ConsoleApp;
using SocialNetworkKata.Core;
using SocialNetworkKata.Core.Repository;
using SocialNetworkKata.Core.Repository.Interface;
using SocialNetworkKata.Core.Service;
using SocialNetworkKata.Core.Service.Interface;

using IHost host = Host.CreateDefaultBuilder(args)
.ConfigureServices((_, services) =>
    services.AddSingleton<IUserService, UserService>()
            .AddSingleton<IPostService, PostService>()
            .AddSingleton<IPostRepository, PostRepository>()
            .AddSingleton<IInMemoryRepository, InMemoryRepository>()
            .AddSingleton<IReadingService, ReadingService>()
            .AddSingleton<IFollowService, FollowService>()
            .AddSingleton<IFollowRepository, FollowRepository>()
    )
.Build();

using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;
provider.GetRequiredService<IUnitOfWork>().PrintMessage();


Task.Run(async () =>
{
    while (true)
    {
        try
        {
            var userInput = Console.ReadLine();
            //Handling for timeline post
            if (userInput.Contains("->"))
            {
                Tuple<string, string> item = CommandHelper.SplitHelper(userInput, "->");
                //Handling for mention
                if (item.Item2.Contains("@"))
                {
                    var args = item.Item2.Split(new String[] { "@" }, StringSplitOptions.RemoveEmptyEntries);
                    var mentionedUserMessage = args[0].Trim();
                    var mentionArg = mentionedUserMessage.Split(new String[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                    var mentionedUser = mentionArg[0].Trim();
                    var mentionedMsg = mentionArg.Length > 1 ? mentionArg[1].Trim() : null;
                    if (mentionedMsg != null)
                    {
                        provider.GetRequiredService<IPostService>().MentionPost(mentionedUser, mentionedMsg, item.Item1);
                    }
                    else
                    {
                        CommandHelper.PrintAcknowledgment($"Error! '/' missing in mention command.Please try again!", false);
                        continue;
                    }
                }
                var user = provider.GetRequiredService<IPostService>().Post(item.Item1, item.Item2);
                CommandHelper.PrintAcknowledgment($"Message posted successfully", true);
            }
            //Handling following
            else if (userInput.Contains("follows"))
            {
                Tuple<string, string> itemFollow = CommandHelper.SplitHelper(userInput, "follows");
                var user = provider.GetRequiredService<IFollowService>().Subscribe(itemFollow.Item1, itemFollow.Item2);
                CommandHelper.PrintAcknowledgment($"{itemFollow.Item1} started following {itemFollow.Item2}", true);
            }
            //Handling user wall
            else if (userInput.Contains("wall"))
            {
                string userName = CommandHelper.SplitHelperShort(userInput, "wall");
                var messages = provider.GetRequiredService<IReadingService>().GetAllPosts(userName);
                if (messages == null)
                {
                    CommandHelper.PrintAcknowledgment($"{userName} - has not posted anything!", false);
                    continue;
                }
                CommandHelper.PrintAcknowledgment(messages, true);
            }
            //Hamdling user post read
            else if (userInput.Contains("reads"))
            {
                Tuple<string, string> itemRead = CommandHelper.SplitHelper(userInput, "reads");
                var messages = provider.GetRequiredService<IReadingService>().GetTimeLinePosts(itemRead.Item2);
                if (messages == null)
                {
                    CommandHelper.PrintAcknowledgment($"{itemRead.Item2} - has not posted anything!", false);
                    continue;
                }
                CommandHelper.PrintAcknowledgment(messages, true);
            }
            //handling direct message
            else if (userInput.Contains("=>"))
            {
                Tuple<string, string> itemDirect = CommandHelper.SplitHelper(userInput, "=>");
                var recieverMessageArg = itemDirect.Item2.Split(new String[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                var reciever = recieverMessageArg[0].Trim();
                var message = recieverMessageArg.Length > 1 ? recieverMessageArg[1].Trim() : null;
                if (message != null)
                {
                    provider.GetRequiredService<IPostService>().SendMessage(itemDirect.Item1, reciever, message);
                    CommandHelper.PrintAcknowledgment($"{itemDirect.Item1} messaged {reciever} : {message}", true);
                }
                else
                {
                    CommandHelper.PrintAcknowledgment($"Error! '/' missing in direct message command. Please try again", false);
                    continue;
                }
            }
            //Handling view direct messages
            else if (userInput.Contains("messages"))
            {
                string reciever = CommandHelper.SplitHelperShort(userInput, "messages");
                var directMessages = provider.GetRequiredService<IReadingService>().GetAllMessages(reciever);
                CommandHelper.PrintAcknowledgment(directMessages, true);
            }
            //Handling read own posts
            else
            {
                var userName = userInput.Trim();
                var messages = provider.GetRequiredService<IReadingService>().GetTimeLinePosts(userName);
                if (messages == null)
                {
                    CommandHelper.PrintAcknowledgment($"{userName} - has not posted anything!", false);
                    continue;
                }
                CommandHelper.PrintAcknowledgment(messages, true);
            }
        }
        catch(IndexOutOfRangeException iex)
        {
            CommandHelper.PrintAcknowledgment($"Error! Invalid Input. Please try again!.Use defined key words", false);
            continue;
        }
        catch(Exception ex)
        {
            CommandHelper.PrintAcknowledgment($"Error! Something went wrong {ex.Message}", false);
        }
    }
}).Wait();

await host.RunAsync();
