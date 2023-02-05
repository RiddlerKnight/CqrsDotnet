using MediatR;
#pragma warning disable CS8618

namespace Application.Aggregators;

public class PublicMessageCommand : INotification
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string Message { get; set; }
}
