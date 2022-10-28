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

        [Theory]
        [InlineData("1 2 3 4", "1 2 5 6")]
        [InlineData("1 2 3 4", "5 2 3 6")]
        [InlineData("1 2 3 4", "5 6 3 4")]
        public void Should_return_2A0B_when_guess_given_the_guess_digits_have_2_digits_with_same_value_location_as_secret_but_2_digits_different(string secret, string guess)
        {
            // given
            var mockSecretGenerater = new Mock<SecretGenerator>();
            mockSecretGenerater.Setup(expression: generater => generater.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerater.Object);
            // when
            var guessResult = game.Guess(guess);
            // then
            Assert.Equal("2A0B", guessResult);
        }

        [Theory]
        [InlineData("1 2 3 4", "1 7 2 6")]
        [InlineData("1 2 3 4", "9 2 4 8")]
        public void Should_return_1A1B_when_guess_given_the_guess_digits_have_1_digits_with_same_value_location_1_digits_with_same_value_different_location_as_secret(string secret, string guess)
        {
            // given
            var mockSecretGenerater = new Mock<SecretGenerator>();
            mockSecretGenerater.Setup(expression: generater => generater.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerater.Object);
            // when
            var guessResult = game.Guess(guess);
            // then
            Assert.Equal("1A1B", guessResult);
        }

        [Fact]
        public void Should_return_secret_with_4_digits_when_generate_secret()
        {
            // given
            SecretGenerator generator = new SecretGenerator();
            // when
            string secret = generator.GenerateSecret();
            // then
            Assert.Equal(4, secret.Split(" ").Length);
        }
    }
}
