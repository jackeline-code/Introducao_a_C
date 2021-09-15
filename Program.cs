using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0; 
            string opcaoUsuario = MenuUsuario();


            //Execução do código a partir da escolha do usuário
            //ToUpper - mesmo que o usuário entre com o x minúsculo ainda assim o comp vai entender
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    //Adicionar aluno
                    case "1":
                    Console.WriteLine("Informe o nome do aluno:");
                    Aluno aluno = new Aluno();//Instancia o objeto aluno
                    aluno.Nome = Console.ReadLine();//Já estou pegando do console e colocando direto no objeto, sem usar variáveis

                    Console.WriteLine("Informe a nota do aluno:");

                    //var inferencia de tipo - não preciso indicar o tipo de variável
                    //var nota = decimal.Parse(Console.ReadLine());
                    if (decimal.TryParse(Console.ReadLine(), out decimal nota)){
                        aluno.Nota = nota;
                    }else{
                        throw new ArgumentException ("Valor da nota deve ser decimal");
                    }

                    alunos[indiceAluno] = aluno;
                    indiceAluno++; //para que o próximo aluno cadastrado seja guardado no próximo array
                    
                        break;
                    //Listar alunos
                    case "2":
                    foreach (var a in alunos) //para cada "a"(aluno) no array imprima uma linha, passando nome e nota
                    {
                        if(!string.IsNullOrEmpty(a.Nome))//Se o nome não for nulo e nem vazio ele vai ser impresso 
                        {
                            //$ significa interpolação, para não precisar concatenar
                        Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}");
                        }                        
                    }

                        break;
                    //Calcular a média geral
                    case "3":
                    decimal notaTotal = 0;
                    var nrAlunos = 0;

                    for (int i=0; i<alunos.Length; i++){
                        if (!string.IsNullOrEmpty(alunos[i].Nome))
                        {
                            notaTotal = notaTotal + alunos[i].Nota;
                            nrAlunos++;
                        }                     
                    }
                        var mediaGeral = notaTotal / nrAlunos;
                        ConceitoEnum conceitoGeral;

                       if(mediaGeral < 2)
                       {
                           conceitoGeral = ConceitoEnum.E; 

                       }else if (mediaGeral < 4)
                       {
                            conceitoGeral = ConceitoEnum.D;

                       }else if (mediaGeral < 6)
                       {
                            conceitoGeral = ConceitoEnum.C;

                       }else if (mediaGeral < 8)
                       {
                            conceitoGeral = ConceitoEnum.B;
                       }else
                       {
                           conceitoGeral = ConceitoEnum.A;
                       }

                        Console.WriteLine($"Média Geral: {mediaGeral} - Conceito: {conceitoGeral}");
                        

                        break;

                    default:
                        throw new ArgumentOutOfRangeException(); //Vai disparar uma excessão que mostra que a opção escolhida esta fora do range de opções do switch

                }
                //Após a escolha efetuada o menu retorna para que o usuário possa escolher outra opção               
                opcaoUsuario = MenuUsuario();
            }            
        }

        private static string MenuUsuario()
        {
            //menu de opções para o meu usuário
            Console.WriteLine(); //Linha em branco para deixar mais legível
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1. Inserir novo aluno");
            Console.WriteLine("2. Listar alunos");
            Console.WriteLine("3. Calcular média geral");
            Console.WriteLine("X. Sair");
            Console.WriteLine(); //Linha em branco para deixar mais legível

            //comando necessário para se obter as respostas do usuário
            //string opcaoUsuario vai guardar as info dos usuários
            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine(); //Linha em branco para deixar mais legível
            return opcaoUsuario;
        }
    }
}
