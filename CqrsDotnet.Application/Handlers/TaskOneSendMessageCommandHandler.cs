﻿using CqrsDotnet.Application.Aggregators;
using MediatR;
using Serilog;

namespace CqrsDotnet.Application.Handlers
{
    public class TaskOneSendMessageCommandHandler : INotificationHandler<PublicMessageCommand>
    {
        public async Task Handle(PublicMessageCommand request, CancellationToken cancellationToken)
        {
            Log.Information("TaskOne Running with message : \"{Message}\"", request.Message);
        }
    }
}
