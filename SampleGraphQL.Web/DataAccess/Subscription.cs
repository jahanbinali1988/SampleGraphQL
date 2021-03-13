using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using SampleGraphQL.Web.DataAccess.Entity;

namespace SampleGraphQL.Web.DataAccess
{
    public class Subscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Department>> OnDepartmentCreate([Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, Department>("DepartmentCreated", cancellationToken);
        }


        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Employee>> OnEmployeeGet([Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, Employee>("ReturnedEmployee", cancellationToken);
        }
    }
}
