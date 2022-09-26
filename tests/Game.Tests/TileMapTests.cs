﻿//-----------------------------------------------------------------------
// <copyright>
//      Created by Matt Weber <matt@badecho.com>
//      Copyright @ 2022 Bad Echo LLC. All rights reserved.
//
//		Bad Echo Technologies are licensed under a
//		GNU Affero General Public License v3.0.
//
//		See accompanying file LICENSE.md or a copy at:
//		https://www.gnu.org/licenses/agpl-3.0.html
// </copyright>
//-----------------------------------------------------------------------

using BadEcho.Game.Pipeline;
using BadEcho.Game.Tiles;
using Xunit;

namespace BadEcho.Game.Tests;

public class TileMapTests : IClassFixture<ContentManagerFixture>
{
    private readonly Microsoft.Xna.Framework.Content.ContentManager _content;

    public TileMapTests(ContentManagerFixture contentFixture) 
        => _content = contentFixture.Content;

    [Theory]
    [InlineData("GrassFourTiles")]
    [InlineData("GrassLeftDownOrder")]
    [InlineData("GrassLargeBlue")]
    [InlineData("GrassTilesAndImage")]
    [InlineData("GrassTwoTileLayers")]
    public void Load_NotNull(string mapName)
    {
        TileMap map = _content.Load<TileMap>($"Tiles\\{mapName}");
        
        Assert.NotNull(map);
    }
    
    [Fact]
    public void Load_GrassFourTiles_ValidOrientation()
    {
        TileMap map = _content.Load<TileMap>("Tiles\\GrassFourTiles");

        Assert.Equal(MapOrientation.Orthogonal, map.Orientation);
    }

    [Theory]
    [InlineData("GrassFourTiles", TileRenderOrder.RightDown)]
    [InlineData("GrassLeftDownOrder", TileRenderOrder.LeftDown)]
    public void Load_ValidRenderOrder(string mapName, TileRenderOrder expectedOrder)
    {
        TileMap map = _content.Load<TileMap>($"Tiles\\{mapName}");

        Assert.Equal(expectedOrder, map.RenderOrder);
    }

    [Theory]
    [InlineData("GrassFourTiles", "#00000000")]
    [InlineData("GrassLargeBlue", "#00aaff")]
    public void Load_ValidBackgroundColor(string mapName, string backgroundColor)
    {
        TileMap map = _content.Load<TileMap>($"Tiles\\{mapName}");

        Assert.Equal(backgroundColor.ToColor(), map.BackgroundColor);
    }

    [Fact]
    public void Load_GrassFourTiles_HasTileLayer()
    {
        TileMap map = _content.Load<TileMap>("Tiles\\GrassFourTiles");

        var tileLayer = map.Layers.OfType<TileLayer>().FirstOrDefault();

        Assert.NotNull(tileLayer);
    }

    [Fact]
    public void Load_GrassTwoTileLayers_HasTwoTileLayers()
    {
        TileMap map = _content.Load<TileMap>("Tiles\\GrassTwoTileLayers");

        Assert.Collection(map.Layers.OfType<TileLayer>(), _ => { }, _ => { });
    }

    [Fact]
    public void Load_GrassFourTiles_HasTileSet()
    {
        TileMap map = _content.Load<TileMap>("Tiles\\GrassFourTiles");

        var tileSet = map.TileSets.FirstOrDefault();

        Assert.NotNull(tileSet);
    }

    [Fact]
    public void Load_GrassFourTiles_HasFourTiles()
    {
        TileMap map = _content.Load<TileMap>("Tiles\\GrassFourTiles");

        var tileLayer = map.Layers.OfType<TileLayer>().First();

        Assert.Equal(4, tileLayer.Tiles.Count);
    }

    [Fact]
    public void Load_GrassFourTiles_UsesThreeUniqueTiles()
    {
        TileMap map = _content.Load<TileMap>("Tiles\\GrassFourTiles");

        var tileLayer = map.Layers.OfType<TileLayer>().First();

        IEnumerable<Tile> tiles = tileLayer.GetRange(0, 10);

        Assert.Equal(3, tiles.GroupBy(t => t.Id).Count());
    }

    [Fact]
    public void Load_GrassTilesAndImage_HasImage()
    {
        TileMap map = _content.Load<TileMap>("Tiles\\GrassTilesAndImage");

        var imageLayer = map.Layers.OfType<ImageLayer>().FirstOrDefault();

        Assert.NotNull(imageLayer);
    }
}