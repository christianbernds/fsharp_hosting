namespace CSharp.WebApi.ExternalTaskHandler
{
    using System.Threading.Tasks;

    using AtlasEngine;
    using AtlasEngine.ExternalTasks;

    [ExternalTaskHandler("Calculation.Add")]
    public class AddHandler : IExternalTaskHandler<AddPayload, AddResult>
    {
        public Task<AddResult> HandleAsync(AddPayload input, ExternalTask task)
        {
            var sum = input.Number1 + input.Number2;
            return Task.FromResult(new AddResult { Sum = sum, Handler = "csharp"});
        }
    }
}
