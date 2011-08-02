using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DojoCore;

namespace Dojo
{
    [TestFixture]
    public class Jogo_Teste
    {
        [TestCase]
        public void Eh_Carta_Alta()
        {
            var aMaiorCarta = new Carta(NumeroCarta.CQ, 'S');

            var cartas = new List<Carta>
            {
                new Carta(NumeroCarta.C1, 'D'),
                new Carta(NumeroCarta.CJ, 'D'),
                new Carta(NumeroCarta.CQ, 'S'),
                new Carta(NumeroCarta.C9, 'H'),
                new Carta(NumeroCarta.C5, 'C')
            };
            Carta maiorCarta = cartas.First();


            for (int i = 0; i < cartas.Count; i++)
            {
                maiorCarta = DescobreMaiorCarta(maiorCarta, cartas[i]);
            }

            Assert.AreEqual(aMaiorCarta, maiorCarta);
        }

        Carta DescobreMaiorCarta(Carta carta1, Carta carta2)
        {
            if ((int)carta1.Numero > (int)carta2.Numero)
                return carta1;
            return carta2;
        }

        [TestCase]
        public void Eh_Um_Par()
        {
            var cartas = new List<Carta>
            {
                new Carta(NumeroCarta.C1, 'D'),
                new Carta(NumeroCarta.CJ, 'D'),
                new Carta(NumeroCarta.CQ, 'S'),
                new Carta(NumeroCarta.C9, 'H'),
                new Carta(NumeroCarta.CQ, 'C')
            };

            Carta primeira = cartas.First();
            bool tempar = false;
            for (int index = 0; index < cartas.Count; index++)
            {
                for (int i = index + 1; i < cartas.Count; i++)
                {
                    if (cartas[index].Numero == cartas[i].Numero)
                    {
                        tempar = true;
                        break;
                    }
                }

            }
            Assert.AreEqual(true, tempar);
        }

        [TestCase]
        public void Tem_Dois_Pares()
        {
            var cartas = new List<Carta>
            {
                new Carta(NumeroCarta.C1, 'D'),
                new Carta(NumeroCarta.CJ, 'D'),
                new Carta(NumeroCarta.CQ, 'S'),
                new Carta(NumeroCarta.C1, 'H'),
                new Carta(NumeroCarta.CQ, 'C')
            };

            var listaDePares = new Dictionary<Carta, Carta>();
            for (int index = 0; index < cartas.Count; index++)
            {
                for (int i = index + 1; i < cartas.Count; i++)
                {
                    if (cartas[index].Numero == cartas[i].Numero)
                    {
                        listaDePares.Add(cartas[index], cartas[i]);
                    }
                }
            }
            Assert.GreaterOrEqual(listaDePares.Count, 2);
        }

        [TestCase]
        public void Tem_Uma_Trinca()
        {
            var cartas = new List<Carta>
            {
                new Carta(NumeroCarta.C1, 'D'),
                new Carta(NumeroCarta.CJ, 'D'),
                new Carta(NumeroCarta.CJ, 'S'),
                new Carta(NumeroCarta.C1, 'H'),
                new Carta(NumeroCarta.C1, 'C')
            };

            var listaTrinca = new List<Carta>();
            var listaResto = new List<Carta>();
            for (int index = 0; index < cartas.Count; index++)
            {
                for (int i = index + 1; i < cartas.Count; i++)
                {
                    for (int j = i + 1; j < cartas.Count; j++)
                    {
                        if (cartas[index].Numero == cartas[i].Numero && cartas[i].Numero == cartas[j].Numero)
                        {
                            listaTrinca.Add(cartas[index]);
                            break;
                        }
                    }
                }
            }

            listaResto = cartas.Where(x => x.Numero != listaTrinca.First().Numero).ToList();

            Assert.AreEqual(1, listaTrinca.Count);
            Assert.AreEqual(2, listaResto.Count);

        }

        [TestCase]
        public void Tem_Uma_Sequencia()
        {
            var cartas = new List<Carta>
            {
                new Carta(NumeroCarta.C1, 'D'),
                new Carta(NumeroCarta.C5, 'D'),
                new Carta(NumeroCarta.C2, 'S'),
                new Carta(NumeroCarta.C3, 'H'),
                new Carta(NumeroCarta.C4, 'C')
            };

            var cartasOrdenadas = cartas.OrderBy(x => x.Numero).ToList();
            bool quebraSequencia = false;
            for (int i = 0; i < cartasOrdenadas.Count - 1; i++)
            {
                if ((cartasOrdenadas[i].Numero + 1) != cartasOrdenadas[i + 1].Numero)
                {
                    quebraSequencia = true;
                    break;
                }
            }

            Assert.IsFalse(quebraSequencia);
        }

        [TestCase]
        public void Tem_Um_Flush()
        {
            var cartas = new List<Carta>
            {
                new Carta(NumeroCarta.C1, 'D'),
                new Carta(NumeroCarta.C5, 'D'),
                new Carta(NumeroCarta.C2, 'D'),
                new Carta(NumeroCarta.C3, 'D'),
                new Carta(NumeroCarta.C4, 'D')
            };

            bool temDiferente = false;
            for (int i = 0; i < cartas.Count - 1; i++)
            {
                if (cartas[i].Naipe != cartas[i + 1].Naipe)
                {
                    temDiferente = true;
                    break;
                }
            }

            Assert.IsFalse(temDiferente);
        }

        [TestCase]
        public void Tem_Uma_Trinca_E_Um_Par()
        {
            var cartas = new List<Carta>
                             {
                                 new Carta(NumeroCarta.C1, 'D'),
                                 new Carta(NumeroCarta.C1, 'O'),
                                 new Carta(NumeroCarta.C1, 'E'),
                                 new Carta(NumeroCarta.C3, 'D'),
                                 new Carta(NumeroCarta.C2, 'O')
                             };

            var listaTrinca = new List<Carta>();
            var listaResto = new List<Carta>();
            for (int index = 0; index < cartas.Count; index++)
            {
                for (int i = index + 1; i < cartas.Count; i++)
                {
                    for (int j = i + 1; j < cartas.Count; j++)
                    {
                        if (cartas[index].Numero == cartas[i].Numero && cartas[i].Numero == cartas[j].Numero)
                        {
                            listaTrinca.Add(cartas[index]);
                            break;
                        }
                    }
                }
            }

            listaResto = cartas.Where(x => x.Numero != listaTrinca.First().Numero).ToList();
            Assert.AreEqual(1, listaTrinca.Count);
            Assert.AreEqual(listaResto.First(), listaResto.Last());
        }

        [TestCase]
        public void Tem_Uma_Quadra()
        {
            var cartas = new List<Carta>
                             {
                                 new Carta(NumeroCarta.C1, 'D'),
                                 new Carta(NumeroCarta.C1, 'O'),
                                 new Carta(NumeroCarta.C1, 'E'),
                                 new Carta(NumeroCarta.C2, 'P'),
                                 new Carta(NumeroCarta.C1, 'O')
                             };

            var listaQuadra = new List<Carta>();
            for (int index = 0; index < cartas.Count; index++)
            {
                for (int i = index + 1; i < cartas.Count; i++)
                {
                    for (int j = i + 1; j < cartas.Count; j++)
                    {
                        for (int k = j + 1; k < cartas.Count; k++)
                        {
                            if (cartas[index].Numero == cartas[i].Numero && cartas[i].Numero == cartas[j].Numero && cartas[j].Numero == cartas[k].Numero)
                            {
                                listaQuadra.Add(cartas[index]);
                                break;
                            }
                        }
                    }
                }
            }

            Assert.AreEqual(1, listaQuadra.Count);
        }

        [TestCase]
        public void Tem_Um_Straight_Flush()
        {
            var cartas = new List<Carta>
            {
                new Carta(NumeroCarta.C1, 'D'),
                new Carta(NumeroCarta.C5, 'D'),
                new Carta(NumeroCarta.C2, 'D'),
                new Carta(NumeroCarta.C3, 'D'),
                new Carta(NumeroCarta.C4, 'D')
            };

            bool temDiferente = false;
            for (int i = 0; i < cartas.Count - 1; i++)
            {
                if (cartas[i].Naipe != cartas[i + 1].Naipe)
                {
                    temDiferente = true;
                    break;
                }
            }

            var cartasOrdenadas = cartas.OrderBy(x => x.Numero).ToList();
            bool quebraSequencia = false;
            for (int i = 0; i < cartasOrdenadas.Count - 1; i++)
            {
                if ((cartasOrdenadas[i].Numero + 1) != cartasOrdenadas[i + 1].Numero)
                {
                    quebraSequencia = true;
                    break;
                }
            }


            Assert.IsFalse(quebraSequencia);
            Assert.IsFalse(temDiferente);
            
        }

        [TestCase]
        public void Tem_Um_Royal_Straight_Flush()
        {
            var cartas = new List<Carta>
            {
                new Carta(NumeroCarta.CA, 'D'),
                new Carta(NumeroCarta.CJ, 'D'),
                new Carta(NumeroCarta.C10, 'D'),
                new Carta(NumeroCarta.CQ, 'D'),
                new Carta(NumeroCarta.CK, 'D')
            };

            bool temDiferente = false;
            for (int i = 0; i < cartas.Count - 1; i++)
            {
                if (cartas[i].Naipe != cartas[i + 1].Naipe)
                {
                    temDiferente = true;
                    break;
                }
            }

            var cartasOrdenadas = cartas.OrderBy(x => x.Numero).ToList();
            bool quebraSequencia = false;
            for (int i = 0; i < cartasOrdenadas.Count - 1; i++)
            {
                if ((cartasOrdenadas[i].Numero + 1) != cartasOrdenadas[i + 1].Numero)
                {
                    quebraSequencia = true;
                    break;
                }
            }


            Assert.IsFalse(quebraSequencia);
            Assert.IsFalse(temDiferente);
            Assert.AreEqual(NumeroCarta.C10, cartasOrdenadas.First().Numero);
        }
    }
}
