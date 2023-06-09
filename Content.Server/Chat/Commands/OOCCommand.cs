using Content.Server.Administration;
using Content.Server.Chat.Managers;
using Content.Shared.Administration;
using Robust.Server.Player;
using Robust.Shared.Console;
using Robust.Shared.IoC;

namespace Content.Server.Chat.Commands
{
    [AnyCommand]
    internal sealed class OOCCommand : IConsoleCommand
    {
        public string Command => "ooc";
        public string Description => "Send Out Of Character chat messages.";
        public string Help => "ooc <text>";

        public void Execute(IConsoleShell shell, string argStr, string[] args)
        {
            if (shell.Player is not IPlayerSession player)
            {
                shell.WriteError("This command cannot be run from the server.");
                return;
            }

            if (args.Length < 1)
                return;

            var message = string.Join(" ", args).Trim();
            if (string.IsNullOrEmpty(message))
                return;

            IoCManager.Resolve<IChatManager>().SendOOC(player, message);
        }
    }
}
