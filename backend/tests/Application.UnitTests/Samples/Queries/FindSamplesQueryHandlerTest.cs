namespace WillEnergy.Application.UnitTests.Samples.Queries
{
    public class FindSamplesQueryHandlerTest : RequestTestBase
    {
        // [Test]
        // public async Task ShouldReturnEmpty()
        // {
        //     var request = new FindSamplesQuery(UserId.Generate());
        //     var handler = new FindSamplesQueryHandler(new SamplesReadRepository(await InitializedContext()), Mapper());
        //
        //     var result = await handler.Handle(request);
        //
        //     result.Should().AllBeOfType<SampleDto>();
        //     result.Should().HaveCount(0);
        // }
        //
        // [Test]
        // public async Task ShouldReturnSamples()
        // {
        //     var request = new FindSamplesQuery(TestUserId());
        //     var handler = new FindSamplesQueryHandler(new SamplesReadRepository(await InitializedContext()), Mapper());
        //
        //     var result = await handler.Handle(request);
        //
        //     result.Should().AllBeOfType<SampleDto>();
        //     result.Should().HaveCount(2);
        // }
    }
}
