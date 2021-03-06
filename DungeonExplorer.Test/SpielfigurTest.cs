﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonExplorer.Objekte;
using NUnit.Framework;

namespace DungeonExplorer.Test
{
    [TestFixture]
    public class SpielfigurTest
    {
        [Test]
        public void SpielerNachObenBewegen()
        {
            short _testPosOben = 9;
            short _testPosLinks = 10;

            Spielfigur _spielfigur = new Spielfigur("Ralph", 10, 10);
            _spielfigur.Bewege(Richtung.Oben);

            Assert.IsTrue(_spielfigur.PosOben == _testPosOben && _spielfigur.PosLinks == _testPosLinks);
        }

        [Test]
        public void SpielernachLinksBewegen()
        {
            short _testPosOben = 10;
            short _testPosLinks = 9;

            Spielfigur _spielfigur = new Spielfigur("Ralph", 10, 10);
            _spielfigur.Bewege(Richtung.Links);

            Assert.IsTrue(_spielfigur.PosOben == _testPosOben && _spielfigur.PosLinks == _testPosLinks);
        }

        [Test]
        public void SpielerNachUntenBewegen()
        {
            short _testPosOben = 11;
            short _testPosLinks = 10;

            Spielfigur _spielfigur = new Spielfigur("Ralph", 10, 10);
            _spielfigur.Bewege(Richtung.Unten);

            Assert.IsTrue(_spielfigur.PosOben == _testPosOben && _spielfigur.PosLinks == _testPosLinks);
        }

        [Test]
        public void SpielerNachRechtsBewegen()
        {
            short _testPosOben = 10;
            short _testPosLinks = 11;

            Spielfigur _spielfigur = new Spielfigur("Ralph", 10, 10);
            _spielfigur.Bewege(Richtung.Rechts);

            Assert.IsTrue(_spielfigur.PosOben == _testPosOben && _spielfigur.PosLinks == _testPosLinks);
        }
    }
}
