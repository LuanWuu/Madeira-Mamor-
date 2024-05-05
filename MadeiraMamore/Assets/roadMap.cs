using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "roadMap", menuName = "talk/characterTalk")]
public class roadMap : ScriptableObject {
    public int amoutWorker = 6;
    public List<string> cheif = new List<string>(){
        // Ao falar com o chefe de equipe para iniciar o trabalho:
        "Chefe: Essa é sua lista. Tudo tem que ser terminado hoje.",
        "Chefe: Nem pense em ficar enrolando.",
        // Durante o trabalho:
        "Chefe: Mais rápido! Não temos o dia todo.",
        "Chefe: Você não é pago pra ficar parado.",
        "Chefe: Muito lento...",
        // Ao terminar o trabalho:
        // Trabalho não feito:
        "Chefe: Se quiser ser pago é melhor trabalhar direito.",
        "Chefe: Continue assim e nem precisa voltar amanhã.",
        // Trabalho ruim:
        "Chefe: Nesse ritmo o trabalho nunca vai acabar.",
        "Chefe: Faça melhor da próxima vez.",
        // Trabalho mediano:
        "Chefe: Medíocre é melhor que nada...",
        "Chefe: Você podia se esforçar como os melhores trabalhadores.",
        // Trabalho bom:
        "Chefe: Mantenha esse desempenho e não teremos problemas.",
        "Chefe: Bom trabalho. Até depois."
        };

    public List<string> guard = new List<string>(){

        // Caso o jogador tente sair do perímetro:
        "Capataz: Pensa que vai aonde?",
        "Guarda: Seu trabalho fica pro outro lado.",
        // Após tentar pela terceira vez seguida:
        "Guarda: Prefere que eu acabe logo com isso?"
        };
    public List<string>[] workerTalkDay1 = new List<string>[6];
    public List<string>[] workerTalkDay2 = new List<string>[6];
    public List<string>[] workerTalkDay12 = new List<string>[6];
    public List<string>[] workerTalkDay20 = new List<string>[6];
    public List<string>[] workerTalkDay22 = new List<string>[6];
    public List<string>[] workerTalkDay25 = new List<string>[6];
    public List<string>[] workerTalkDay26 = new List<string>[6];
    public List<string>[] workerTalkDay27 = new List<string>[6];

    public void InitializeWorkerTalkDay1(){
        workerTalkDay1[0] = new List<string>{// Dia 1
            "T1: Mais um dia, mais trabalho.",
            "T1: Quando esse ciclo vai acabar?",
            // Protagonista: Quando a ferrovia estiver pronta.
            "T1: Isso só até arranjarmos outro emprego tão ruim quanto esse.",
            // P: Nunca.
            "T1: haha você tá certo, só quando morrermos seremos livres."
            };
        workerTalkDay1[1] = new List<string>{// Dia 1
            "T2: Uuhhh esse trabalho ainda vai me matar.",
            "T2: Seria tão bom ter uma folga..."
            };
        workerTalkDay1[2] = new List<string>{// Dia 1
            "T3: *matando um mosquito* meu sangue deve ser muito bom.",
            "T3: Essa maldita floresta tá cheia de mosquito.",
            "T3: E eles tão me usando de almoço."
            };
        workerTalkDay1[3] = new List<string>{
            // Dia 1
            "T4: ampolk merlous fidim"
            };
        workerTalkDay1[5] = new List<string>{
            // Noite 1:
            "T6: Ah, Álcool, uma das melhores coisas inventadas.",
            "T6: Como eles podem proibir algo tão bom? Isso é o que me faz mais produtivo! Como esperam que eu viva sem?",
            "T6: A gente não devia continuar aguentando essas regras sem sentido.",
            // P: Talvez tenha motivo pra essas regras.
            "T6: Não seja burro! E não seja hipócrita! Diz que fazem sentido mas veio beber...",
            // P: Não aguento mais essas regras.
            "T6: Hmm eu ouvi um conhecido falando sobre um lugar interessante aqui perto...",
            "T6: Talvez eu tenha um plano, mas talvez esteja meio bêbado..",
            "T6: Discutimos isso outra noite?"       
            };
    }
    public void InitializeWorkerTalkDay2(){
        workerTalkDay2[0] = new List<string>{// Dia 2: o jogo assume seu ritmo normal e as escolhas noturnas são desbloqueadas.
            "T1: Ei, [protagonista], você vem jogar poker hoje?",
            // P: Não.
            "T1: Pois está perdendo a melhor parte desse lugar.",
            // P: Sim.
            "T1: É assim que tem que ser! Te espero lá, amigo.",
            "T1: Nada aqui tem muito sentido sem umas apostas de vez em quando."
            };
        workerTalkDay2[1] = new List<string>{ // Dia 2
            "T2: Ouvi que demitiram alguns trabalhadores por não serem “eficientes o suficiente”.",
            "T2: Talvez se esse lugar não fosse um inferno nós seriamos mais produtivos."
            };
        workerTalkDay2[2] = new List<string>{// Dia 2
            "T3: Nada de dormir cedo hoje!",
            "T3: Encontre a gente de noite.",
            "T3: *sussurrando* temos bebidas."
            };
        workerTalkDay2[3] = new List<string>{// Dia 2
            "T4: elkool prelcho"
            };
        workerTalkDay2[5] = new List<string>{ // Noite 2:
            "T6: Você voltou! Estávamos discutindo o plano.",
            "T6: O que acha de ganhar um pouco mais? Dinheiro sempre é bom!",
            "T6: Borracha em alta, poder comprar armas e sair da ferrovia. O que acha?",
            "T6: Se estiver de acordo, vamos sair daqui na próxima noite de álcool, depois de uma bebida final.",
            "T6: Ao seringueiro! Não vai se arrepender."};
    }
    public void InitializeWorkerTalkDay12(){
        workerTalkDay12[0] = new List<string>{// Dia 12: Alguns trabalhadores parecem doentes. Esse dia serve como uma introdução às condições ruins de saúde.
            "T1: Aqueles homens não parecem bem.",
            "T1: Quanto tempo será que ainda aguentam?",
            "T1: E quanto tempo até serem substituídos?",
            "T1: Logo seremos só eu e você, amigo."
            };
        workerTalkDay12[1] = new List<string>{// Dia 12
            "T2: Tantos doentes.",
            "T2: Deve ser culpas dessas barracas.",
            "T2: Alguns lugares da ferrovia têm casas, mas a gente têm só essas barracas de lona."
            };
        workerTalkDay12[2] = new List<string>{ // Dia 12
            "T3: Não... posso parar...",
            // P: Você tá bem?
            "T3: Me sinto doente.",
            "T3: O dia podia... acabar logo.",
            // P: Talvez devesse parar.
            "T3: Preciso... do dinheiro.",
            "T3: Não pagam pra... ficar... no hospital.",
            // P: ...
            "T3: Você deveria... ficar longe."
            };
        workerTalkDay12[3] = new List<string>{// Dia 12
            "T4: aamkel"
            };
        workerTalkDay12[5] = new List<string>{// Noite 12:
            "T6: Ao seringueiro! Não vai se arrepender."};
    }
    public void InitializeWorkerTalkDay20(){
        workerTalkDay20[0] = new List<string>{// Dia 20: Um novo grupo de trabalhadores chega, demonstrando a constante circulação de novos trabalhadores para substituir os antigos.
            // O novo grupo de trabalhadores é composto por estrangeiros, assim tendo suas 
            // falas incompreensivas (como do Trabalhador 4) e geram uma sensação maior de estranheza, desconhecido e isolamento.
            "T1: Um grupo de homens novos, sabe o que significa?",
            "T1: Os outros devem ter morrido.",
            "T1: Seremos os próximos, é impossível ficar tanto tempo vivo aqui.",
            "T1: E tudo isso pra que?",
            // P: Pela ferrovia.
            "T1: Você realmente acredita no que dizem sobre a importância desse trabalho?",
            "T1: Eu duvido de tudo que nos contam.",
            // P: Pelo dinheiro.
            "T1: Tanto trabalho e morte só pelo dinheiro..."
            };
        workerTalkDay20[1] = new List<string>{// Dia 20
            "T2: Veio se despedir? Vou embora essa tarde.",
            "T2: Espero que tenha uma casa pra onde me transferiram...",
            "T2: Nem me importaria em dividir ela com tanta gente, só quero um lugar mais decente pra dormir."};
    }
    public void InitializeWorkerTalkDay22(){
        workerTalkDay22[0] = new List<string>{// Dia 22: Nesse dia o Trabalhador 1 foge floresta adentro, tentando voltar para sua casa.
            // Esse dia dá a possibilidade do jogador tentar fugir e assim alcançar um final alternativo.
            "T1: Você já pensou em tentar voltar pra casa?",
            // P: Não.
            "T1: Nem mesmo uma vez? Invejo você...",
            "T1: Queria ser tão despreocupado assim.",
            // P: Sim.
            "T1: Então você me entende.",
            "T1: Mas é difícil sair daqui com tantos capatazes.",
            "T1: Ainda assim eu preciso tentar.",
            "T1: Eu não aguento mais esse lugar, cansei disso tudo. Só quero ver minha família de novo.",
            "T1: *sussurrando* Hoje a noite vou fugir, prefiro tirar a sorte nessa mata do que ficar mais um dia nesse inferno.",
            "T1: Me deseje sorte.",
            // P: Boa sorte.
            "T1: Se sair daqui vivo, espero que possamos nos reencontrar pra uma bebida. Talvez até uma última rodada de poker.",
            // P: Mas é muito perigoso.
            "T1: Aqui também é.",
            "T1: É só mais um risco, uma última aposta.",
            "T1: Te vejo do outro lado, amigo."
            };
    }
    public void InitializeWorkerTalkDay25(){
        workerTalkDay25[4] = new List<string>{// Dia 25: Ocorre um deslizamento durante a noite anterior,
            // fazendo com que parte dos trilhos seja destruída. Isso faz com que o jogador tenha que realizar o Trabalho B para arrumar os trilhos.
            "T5: Eu chego aqui ontem e já tenho q arrumar essa bagunça?",
            "T5: Não bastava me transferir sem avisar antes?"
            };
    }
    public void InitializeWorkerTalkDay26(){
        workerTalkDay26[4] = new List<string>{// Dia 26: O conserto dos trilhos é finalizado neste dia,
            // fazendo com que o jogador trabalhe durante a noite ao invés de escolher o que fazer. 
            // (Durante o dia realizaria o Trabalho B e de noite o Trabalho A, para compensar o tempo que o trem teria ficado parado).
            // Este também é o dia em que o jogador começa a ter sintomas da malária.
            "T5: Certeza que vão fazer a gente trabalhar até tarde hoje...",
            "T5: Maldito deslizamento."
            };
    }
    public void InitializeWorkerTalkDay27(){
        workerTalkDay27[4] = new List<string>{ // Dia 27: Os sintomas do jogador pioram, tornando o trabalho ainda mais difícil.
            "T5: Tá se sentindo bem?",
            "T5: Ainda aguenta depois de ontem?",
            // P: Tá tudo bem.
            "T5: Não parece...",
            // P: Talvez esteja doente.
            "T5: Deve ter sido um desses mosquitos.",
            "T5: Eu vi um homem que vivia reclamando deles morrer."
            };

    }
}
