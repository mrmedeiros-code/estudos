using System;
using System.Data.Common;
using Microsoft.VisualBasic;

namespace MiniGameProject
{

    class Goblin
    {
        public int life = 100;
        public int doDamage = 10;
    }

    class Character
    {
        public int life = 150;
        public int potion = 5;
        public int potionCure = 25;
    }

    class Options
    {
        public string? chooseOptions { get; set; }
    }
    class Weapons
    {
        public int OccupeSpace { get; set; }
        public string? NameWeapon { get; set; }
        public int Damage { get; set; }
        public int Arrows { get; set; }

        public override string ToString()
        {
            return NameWeapon ?? "Sem nome";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "Mercador: Olá, jovem guerreiro! Vejo que tem uma bolsa na qual ocupa 10 espaços. Vamos lá, escolha sua arma: "
            );

            int inventorySpace = 10;

            List<Weapons> weapon = new List<Weapons>
            {
                new Weapons {OccupeSpace = 5, NameWeapon = "Espada", Damage = 6},
                new Weapons {OccupeSpace = 4, NameWeapon = "Faca pequena", Damage = 4},
                new Weapons {OccupeSpace = 7, NameWeapon = "Arco", Damage = 7, Arrows = 2}
            };

            for (int i = 0; i < weapon.Count; i++)
            {
                Console.WriteLine($"{i} : {weapon[i]}, Ocupa: {weapon[i].OccupeSpace}, Dano: {weapon[i].Damage}");
            }

            string? entradaUser = Console.ReadLine();
            int indice;

            if (int.TryParse(entradaUser, out indice) && indice >= 0 && indice < weapon.Count)
            {
                inventorySpace -= weapon[indice].OccupeSpace;
                Console.WriteLine("Você selecionou: " + weapon[indice].NameWeapon + "\n" + "Seu espaço atual no inventário é: " + inventorySpace);

                if (indice == 2)
                {
                    Console.WriteLine("Quantidade de flechas: " + weapon[indice].Arrows);
                }

                Console.WriteLine(
                    "\n\nMercador: Pode ficar, é de graça haha! Na verdade... Não, vou querer um favor em troca. Poderia matar o goblin que está andando por aqui já algum tempo? \nEle anda roubando minhas coisas, por isso só te ofereci apenas 3 armas, PORQUE ELE JA ROUBOU TUDO! \nPoderá fazer isso por mim?"
                );

                string? escolha = Console.ReadLine();
                if (!string.IsNullOrEmpty(escolha) && escolha.ToLower() == "sim")
                {
                    Console.WriteLine("Mercador: Muito obrigado! Te entregarei uma recompensa pela cabeça desse maldito goblin. \n\n*Você espera anoitecer para procurar pela floresta, e de repente, PAM! Ele te viu e está indo na sua direção, prepare-se para lutar!*");

                    // criar uma lista que contem opções para o jogador escolher entre elas. Colocar taxa de porcentagem de acerto por golpe e tentar utilizar um método
                    List<Options> opcoes = new List<Options>
                    {
                        new Options { chooseOptions = "Atacar" },
                        new Options { chooseOptions = "Beber poção" },
                        new Options { chooseOptions = "Fugir" }
                    };

                    for (int j = 0; j < opcoes.Count; j++)
                    {
                        Console.WriteLine($"{j} : {opcoes[j].chooseOptions}");
                    }

                    string? entradaUserSecond = Console.ReadLine();
                    int indiceSecond;
                    if (int.TryParse(entradaUserSecond, out indiceSecond) && indiceSecond >= 0 && indiceSecond <= opcoes.Count)
                    {
                        switch (indiceSecond)
                        {
                            case 0:
                                Console.WriteLine("voce atacou!");
                                break;
                            case 1:
                                Console.WriteLine("voce bebeu a poção");
                                break;
                            case 2:
                                Console.WriteLine("voce fugiu");
                                break;
                            default:
                                //descobrir uma maneira de se vier para o default, voltar e escolher outra opção(while).
                                Console.WriteLine("Escolhe direito porra");
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Mercador: Ora seu pilantra, então me devolva o que eu te dei!\n\nFim de jogo.");
                }
            }
            else
            {
                Console.WriteLine("Mercador: Oh, hoho, mas esse item eu não tenho! \n\nFim de jogo.");
            }

        }
    }
}
