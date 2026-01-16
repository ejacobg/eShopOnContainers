namespace IntegrationEventLog.Models;

// TODO: Rename to EventState
public enum EventStateEnum
{
    NotPublished = 0,
    InProgress = 1,
    Published = 2,
    PublishedFailed = 3
}
