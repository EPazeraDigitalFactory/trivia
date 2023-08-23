using System;
using Trivia;
using Xunit;
using Shouldly;

public class Game_should
{
    [Fact]
    public void Game_Should_Start_With_No_Players()
    {
        Game game = new Game();
        game.HowManyPlayers().ShouldBe(0);
        game.IsPlayable().ShouldBe(false);
    }

    [Fact]
    public void Game_Should_Have_One_Player()
    {
        Game game = new Game();
        game.Add("George");
        game.HowManyPlayers().ShouldBe(1);
        game.IsPlayable().ShouldBe(false);
    }

    [Fact]
    public void Game_Should_Allow_Two_Players()
    {
        Game game = new Game();
        game.Add("George");
        game.Add("Lenny");
        game.HowManyPlayers().ShouldBe(2);
        game.IsPlayable().ShouldBe(true);
    }

    [Fact]
    public void Game_Should_Allow_Three_Players()
    {
        Game game = new Game();
        game.Add("George");
        game.Add("Lenny");
        game.Add("Rabbit");
        game.HowManyPlayers().ShouldBe(3);
        game.IsPlayable().ShouldBe(true);
    }

    [Fact]
    public void Game_Should_Allow_Four_Players()
    {
        Game game = new Game();
        game.Add("George");
        game.Add("Lenny");
        game.Add("Rabbit");
        game.Add("Curly's Wife");
        game.HowManyPlayers().ShouldBe(4);
        game.IsPlayable().ShouldBe(true);
    }

    [Fact]
    public void Game_Should_Allow_Five_Players()
    {
        Game game = new Game();
        game.Add("George");
        game.Add("Lenny");
        game.Add("Rabbit");
        game.Add("Curly's Wife");
        game.Add("Old Guy");
        game.HowManyPlayers().ShouldBe(5);
        game.IsPlayable().ShouldBe(true);
    }

    // [Fact]
    // public void Game_Should_Allow_Six_Players()
    // {
    //     Game game = new Game();
    //     game.Add("George");
    //     game.Add("Lenny");
    //     game.Add("Rabbit");
    //     game.Add("Curly's Wife");
    //     game.Add("Old Guy");
    //     game.Add("???");
    //     game.HowManyPlayers().ShouldBe(6);
    //     game.IsPlayable().ShouldBe(true);
    // }

}