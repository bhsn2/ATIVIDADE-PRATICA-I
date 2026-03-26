using System;
using System.Collections.Generic;
using System.Linq;
					
class Exercicio
{
	public static void Main()
	{
		int opcao = 8;
		List<String> nome = new List<String>();
		List<String> grupoMuscular = new List<String>();
		List<float> carga = new List<float>();
		List<int> reps = new List<int>();
		float valorCarga = 0;
		int qtdReps = 0;
		String resp = "";
		
		
		while (true) {
			Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1 - Adicionar exercício");
            Console.WriteLine("2 - Listar exercícios");
            Console.WriteLine("3 - Buscar exercício por nome");
            Console.WriteLine("4 - Filtrar por grupo musuclar");
			Console.WriteLine("5 - Calcular carga total de um treino");
			Console.WriteLine("6 - Exibir exercício mais pesado");
			Console.WriteLine("7 - Remover exercício");
			Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");
			
			if(!int.TryParse(Console.ReadLine(), out opcao) || opcao < 0 || opcao > 7)
			{
				Console.WriteLine("\nEntrada inválida. Digite um número entre 0 e 7.");
				continue;
			}
			
			if (opcao == 0) {
				break; 
			}
			
			switch (opcao)
			{
				case 1:
					Console.WriteLine("\nInforme o nome do exercício: ");
					nome.Add(Console.ReadLine());
					
					Console.WriteLine("\nInforme o grupo muscular desse exercício: ");
					grupoMuscular.Add(Console.ReadLine());
					
					Console.WriteLine("\nInforme a carga em kg: ");
					while (true) {

						if (float.TryParse(Console.ReadLine(), out valorCarga) && valorCarga >= 0) {
							carga.Add(valorCarga);
							break;
						}
						else {
							Console.WriteLine("\nCarga inválida. Informe uma valor numérico e maior que 0.");	
						}
					}
					
					while (true) {
						Console.WriteLine("\nInforme a quantidade de repetições");
						if (int.TryParse(Console.ReadLine(), out qtdReps) && qtdReps >= 1) {
							reps.Add(qtdReps);
							break;
						}
						else {
							Console.WriteLine("\nQuant. de repetições inválida. Informe um valor numérico e maior/igual a 1.");
						}
					}
					
				break;
				
				case 2:
					Console.WriteLine("\nLISTA DE EXERCÍCIOS REGISTRADOS: ");
					for (int i = 0; i < nome.Count; i++) 
					{
						Console.WriteLine("Nome: "+ nome[i] +" - Grupo Muscular: "+ grupoMuscular[i] +" - Carga: "+ carga[i] +"kg - Repetições: "+ reps[i]);
					}
					
				break;
					
				case 3:
					Console.WriteLine("\nNome do exercício que deseja buscar: ");
					resp = Console.ReadLine();
					
					var resultadoBuscaNome = from i in Enumerable.Range(0, nome.Count)
										 where nome[i].ToLower() == resp.ToLower()
										 select i;
					
					bool encontrado = false;
					
					foreach (int i in resultadoBuscaNome) 
					{
						Console.WriteLine("\nNome: "+ nome[i] +" - Grupo Muscular: "+ grupoMuscular[i] +" - Carga: "+ carga[i] +"kg - Repetições: "+reps[i]);
						encontrado = true;
					}
					
					if (!encontrado) {
						Console.WriteLine("\nExercício não encontrado.");	
					}
					
				break;
					
				case 4:
					Console.WriteLine("\nFiltrar exercícios por grupo musuclar: ");
					resp = Console.ReadLine();
					
					var resultadoFiltroGrupo = from i in Enumerable.Range(0, grupoMuscular.Count)
										  where grupoMuscular[i].ToLower() == resp.ToLower()
										  select i;
					encontrado = false;
						
					foreach (int i in resultadoFiltroGrupo) 
					{
						Console.WriteLine("\nNome: "+ nome[i] +" - Grupo Muscular: "+ grupoMuscular[i] +" - Carga: "+ carga[i] +"kg - Repetições: "+ reps[i]);
						encontrado = true;
					}
					
					if (!encontrado) {
						Console.WriteLine("\nGrupo muscular não encontrado.");	
					}
				break;
					
				case 5:
					float cargaTotal = 0;
					
					cargaTotal = carga.Sum();
					Console.WriteLine("\nCarga total de um treino: " + cargaTotal + "kg.");

				break;
					
				case 6:
					Console.WriteLine("\nExercício mais pesado: ");
					Console.WriteLine("Nome: "+ nome[carga.IndexOf(carga.Max())] +"- Carga: "+ carga[carga.IndexOf(carga.Max())]);
				break;
					
				case 7:
					Console.WriteLine("\nInforme o nome do exercício a ser removido: ");
					resp = Console.ReadLine();
					
					int indiceRemover = -1;

					for (int i = 0; i < nome.Count; i++)
					{
						if (nome[i].ToLower() == resp.ToLower())
						{
							indiceRemover = i;
							break;
						}
					}
					if (indiceRemover != -1) {
						nome.RemoveAt(indiceRemover);
						grupoMuscular.RemoveAt(indiceRemover);
						carga.RemoveAt(indiceRemover);
						reps.RemoveAt(indiceRemover);

						Console.WriteLine("Exercício removido.");
					}
					else
					{
						Console.WriteLine("Exercício não encontrado.");
					}
					
				break;
			}
		}
	}
}