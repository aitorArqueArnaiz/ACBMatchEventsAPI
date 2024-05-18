using FluentAssertions;
using MatchEvent.Domain.Interfaces;
using MatchEvents.Domain.Dtos;
using MatchEvents.Domain.Dtos.Player;
using MatchEvents.Domain.Interfaces;
using MatchEvents.Domain.Services;
using Moq;
using System.ComponentModel;

namespace MatchEventsApi.Tests
{
    public class MatchEventTests
    {
        private readonly IAcbMatchEventService _matchEventService;
        private readonly Mock<IMatchEventApiRestRepository> _matchEventApirepositoryMock;
        private readonly Mock<IInMemmoryRepository> _inMemmoryRepositoryMock;

        public MatchEventTests()
        {
            _matchEventApirepositoryMock = new Mock<IMatchEventApiRestRepository>();
            _inMemmoryRepositoryMock = new Mock<IInMemmoryRepository> { CallBase = true };
            _matchEventService = new AcbMatchEventService(_matchEventApirepositoryMock.Object, _inMemmoryRepositoryMock.Object);
        }

        [Fact]
        [Description("Test intended to check the ACB reponse API call with mocked data when the game id provided it is NOT present in the in memmory repository")]
        public async void Php_Lean_When_New_Data_Is_Generated_By_ApiCall()
        {
            // arrange
            int gameId = 103789;
            long? playerLicense = 123456;
            long teamId = 12;
            _inMemmoryRepositoryMock.Setup(x => x.GetMatchEventsAsync(It.IsAny<int>()))
                .ReturnsAsync(new List<MatchEventInfo>() { });
            _matchEventApirepositoryMock.Setup(x => x.GetAcbMatchEventAsync(It.IsAny<int>()))
                .ReturnsAsync(new List<MatchEventInfo>() { new MatchEventInfo()
                {
                    ActionTime = DateTime.UtcNow.ToString(),
                    ActionType = 1,
                    GameId = 103789,
                    PlayerLicense = playerLicense,
                    Team = new Team() { TeamId = teamId } } 
                });

            // act
            var response = await _matchEventService.GetPhpLeanAsync(gameId);

            // assert
            response.Should().NotBeEmpty();
            _inMemmoryRepositoryMock.Verify(x => x.GetMatchEventsAsync(It.IsAny<int>()), Times.Once());
            _matchEventApirepositoryMock.Verify(x => x.GetAcbMatchEventAsync(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        [Description("Test intended to check the ACB reponse API call with mocked data when the game id provided it is NOT present in the in memmory repository")]
        public async void Php_Lean_When_New_Data_Is_Present_In_Repository()
        {
            // arrange
            int gameId = 103789;
            long? playerLicense = 123456;
            long teamId = 12;
            _inMemmoryRepositoryMock.Setup(x => x.GetMatchEventsAsync(It.IsAny<int>()))
                .ReturnsAsync(new List<MatchEventInfo>() { });
            _matchEventApirepositoryMock.Setup(x => x.GetAcbMatchEventAsync(It.IsAny<int>()))
                .ReturnsAsync(new List<MatchEventInfo>() { new MatchEventInfo() });

            // act
            var response = await _matchEventService.GetPhpLeanAsync(gameId);

            // assert
            response.Should().NotBeEmpty();
            _inMemmoryRepositoryMock.Verify(x => x.GetMatchEventsAsync(It.IsAny<int>()), Times.Once());
            _matchEventApirepositoryMock.Verify(x => x.GetAcbMatchEventAsync(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        [Description("Test intended to check the calculation of the game leaders given the game Idetifier.")]
        public async void Calculate_Game_leaders()
        {
            // arrange
            int gameId = 103789;
            long? playerLicense = 123456;
            long teamId = 12;
            _inMemmoryRepositoryMock.Setup(x => x.GetMatchEventsAsync(It.IsAny<int>()))
                .ReturnsAsync(new List<MatchEventInfo>() { });
            _matchEventApirepositoryMock.Setup(x => x.GetAcbMatchEventAsync(It.IsAny<int>()))
                .ReturnsAsync(new List<MatchEventInfo>() { new MatchEventInfo()
                {
                    ActionTime = DateTime.UtcNow.ToString(),
                    ActionType = 1,
                    GameId = 103789,
                    PlayerLicense = playerLicense,
                    Team = new Team() { TeamId = teamId } }
                });

            // act
            var response = await _matchEventService.GetGameLeadersAsync(gameId);

            // assert
            _matchEventApirepositoryMock.Verify(x => x.GetAcbMatchEventWithStatisticsAsync(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        [Description("Test intended to check the calculation of the team biggets difference given the game Idetifier.")]
        public async void Calculate_Game_Biggest_Points_difference()
        {
            // arrange
            int gameId = 103789;
            long? playerLicense = 123456;
            long teamId = 12;
            _inMemmoryRepositoryMock.Setup(x => x.GetMatchEventsAsync(It.IsAny<int>()))
                .ReturnsAsync(new List<MatchEventInfo>() { });
            _matchEventApirepositoryMock.Setup(x => x.GetAcbMatchEventAsync(It.IsAny<int>()))
                .ReturnsAsync(new List<MatchEventInfo>() { new MatchEventInfo()
                {
                    ActionTime = DateTime.UtcNow.ToString(),
                    ActionType = 1,
                    GameId = 103789,
                    PlayerLicense = playerLicense,
                    Team = new Team() { TeamId = teamId } }
                });

            // act
            var response = await _matchEventService.GetGameBiggestLeadAsync(gameId);

            // assert
            _matchEventApirepositoryMock.Verify(x => x.GetAcbMatchEventWithStatisticsAsync(It.IsAny<int>()), Times.Once());
        }
    }
}