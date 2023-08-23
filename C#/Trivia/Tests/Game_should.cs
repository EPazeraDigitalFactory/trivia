using System;
using Trivia;
using Xunit;
using Shouldly;
using System.Collections.Generic;
using System.Linq;

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
        List<string> Output = new List<string>();
        
        Game game = new Game(Output.Add);
        game.Add("George");
        game.Add("Lenny");
        game.Add("Rabbit");
        game.Add("Curly's Wife");
        game.Add("Old Guy");
        game.HowManyPlayers().ShouldBe(5);
        game.IsPlayable().ShouldBe(true);
        Output.Count.ShouldBe(10);
    }

    [Fact]
    public void Roll_Should_Advance_Unpenalized_Player()
    {
        List<string> Output = new List<string>();
        List<string> Categories = new List<string>(){"Rock","Pop","Science","Sports"};
        
        Game game = new Game(Output.Add);
        game.Add("George");
        game.Add("Lenny");
        Output.Clear();
        game.Roll(3);
        Output[2].ShouldContain("George's new location is");
        Categories.Any(x=>Output[4].StartsWith(x)).ShouldBeTrue();
        Output.Count.ShouldBe(5);
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