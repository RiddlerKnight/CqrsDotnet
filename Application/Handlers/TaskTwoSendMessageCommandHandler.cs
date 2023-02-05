using Application.Aggregators;
using MediatR;
using Serilog;

namespace Application.Handlers
{
    public class TaskTwoSendMessageCommandHandler : INotificationHandler<PublicMessageCommand>
    {
        public async Task Handle(PublicMessageCommand request, CancellationToken cancellationToken)
        {
            Log.Information("TaskTwo Running with message : \"{Message}\"", request.Message);
        }
    }
}
