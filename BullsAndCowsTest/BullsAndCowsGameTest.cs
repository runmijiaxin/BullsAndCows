using BullsAndCows;
using Moq;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        [Fact]
        public void Should_create_BullsAndCowsGame()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            Assert.NotNull(game);
            Assert.True(game.CanContinue);
        }

        [Fact]
        public void Should_return_4A0B_when_guess_given_guess_digits_are_same_as_secret()
        {
            // given
            var mockSecretGenerater = new Mock<SecretGenerator>();
            mockSecretGenerater.Setup(expression: generater => generater.GenerateSecret()).Returns("1 2 3 4");
            var game = new BullsAndCowsGame(mockSecretGenerater.Object);
            // when
            var guessResult = game.Guess("1 2 3 4");
            // then
            Assert.Equal("4A0B", guessResult);
        }

        [Fact]
        public void Should_return_2A0B_when_guess_given_the_guess_digits_have_2_digits_with_same_value_location_as_secret_but_2_digits_different()
        {
            // given
            var mockSecretGenerater = new Mock<SecretGenerator>();
            mockSecretGenerater.Setup(expression: generater => generater.GenerateSecret()).Returns("1 2 3 4");
            var game = new BullsAndCowsGame(mockSecretGenerater.Object);
            // when
            var guessResult = game.Guess("1 2 5 6");
            // then
            Assert.Equal("2A0B", guessResult);
        }
    }
}
