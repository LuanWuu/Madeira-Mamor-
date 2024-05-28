using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "roadMap", menuName = "talk/characterTalk")]
public class roadMap : ScriptableObject {
    public int amoutWorker = 6;
    public bool answer;
    public List<string> cheif = new List<string>(){};
    public List<string> chiefScrean = new List<string>(){
        // Durante o trabalho:
        "Venha falar comigo quando acoradar",
        "Mais rápido! Não temos o dia todo.",
        "Tu não és pago para ficar parado.",
        "Estás indo muito devagar..."
        };
    public List<string> guard = new List<string>(){
        // Caso o jogador tente sair do perímetro:
        "Pensa que vai aonde?",
        "Seu trabalho fica pro outro lado.",
        // Após tentar pela terceira vez seguida:
        "Prefere que eu acabe logo com isso?"
        };
    public List<string> worker0AnswerPositive;
    public List<string> worker0AnswerNegative;
    public List<string> worker0AnswerPositive2Day22 = new List<string>(){
        // P: Mas é muito perigoso.
        "Aqui também é.",
        "É só mais um risco, uma última aposta."
    };
    public List<string> worker0AnswerNegative2Day22= new List<string>(){
        // P: Boa sorte.
        "Se sair daqui vivo, espero que possamos nos reencontrar pra uma bebida. Talvez até uma última rodada de poker."
        };
    public List<string> worker2AnswerPositive = new List<string>(){
            // P: ...
        "Você deveria... afastar-se."
    };
    public List<string> worker2AnswerNegative = new List<string>(){
        // P: Talvez devesse parar.
        "Preciso...do dinheiro.",
        "Não pagam para... ficar de... cama no hospital."
    };
    public List<string> worker4AnswerPositive = new List<string>(){  
        // P: Talvez esteja doente.
        "Há de ter sido um destes mosquitos.",
        "Vi um homem que vivia a reclamar deles morrer."
        };
    public List<string> worker4AnswerNegative = new List<string>(){
        // P: Tá tudo bem.
        "Não parece...",
    };
    public List<string> worker5AnswerPositive = new List<string>(){
        // P: Não aguento mais essas regras.
        "Hmm eu ouvi um conhecido falando sobre um lugar interessante aqui perto...",
        "Talvez eu possa ter um plano, mas estou meio bêbado...",
        "Discutimos isto outra noite?"    
    };
    public List<string> worker5AnswerNegative = new List<string>(){
        // P: Talvez tenha motivo pra essas regras.
        "Não seja burro! E não seja hipócrita! Diz que fazem sentido, mas veio beber mesmo assim..."       
    };
    public List<string> workerSpecial = new List<string>();
    public List<string>[] workerTalkDay1 = new List<string>[6];
    public List<string>[] workerTalkDay2 = new List<string>[6];
    public List<string>[] workerTalkDay12 = new List<string>[6];
    public List<string>[] workerTalkDay20 = new List<string>[6];
    public List<string>[] workerTalkDay22 = new List<string>[6];
    public List<string>[] workerTalkDay25 = new List<string>[6];
    public List<string>[] workerTalkDay26 = new List<string>[6];
    public List<string>[] workerTalkDay27 = new List<string>[6];

    public List<string>[] NotTalkMoment = new List<string>[6];

    public List<string>[] playerAnswers = new List<string>[6];
    public void NotWords(){
        NotTalkMoment[0] = new List<string>(){
            "Podemos conversar em nossa pausa."
        };
        NotTalkMoment[1] = new List<string>(){
            "Não há tempo de conversar agora."
        };
        NotTalkMoment[2] = new List<string>(){
            "Melhor ir trabalhar para evitar problemas."
        };
        NotTalkMoment[3] = new List<string>(){
            "Ase me isicho"
        };
        NotTalkMoment[4] = new List<string>(){
            "Deixe-me trabalhar."
        };
        NotTalkMoment[5] = new List<string>(){
            "Companhia de merda, a seringueira paga mais."
        };
    }
    public void ChefWords(){
        cheif = new List<string>(){ 
            // Ao falar com o chefe de equipe para iniciar o trabalho:
            "Esta é tua lista. Tudo há de ser terminado hoje.",
            "Nem pense em ficar enrolando."
        };
    }
    public void GoodWork(){
        cheif = new List<string>(){ 
            // Trabalho bom:
            "Mantenha esse desempenho e não teremos problemas.",
            "Bom trabalho. Aproveite a pausa, fale comigo quando estiver pronto para o próximo turno"
        };
    }
    public void MediumWork(){
        cheif = new List<string>(){ 
            // Trabalho mediano:
            "Medíocre é melhor que nada...",
            "Tu podias esforçar-se como os outros.",
            "Fale comigo quando estiver pronto para o próximo turno"
        };
    }
    public void BadWork(){
        cheif = new List<string>(){ 
            // Trabalho ruim:
            "Neste ritmo o trabalho nunca acabará.",
            "Faça melhor da próxima vez.",
            "Volte logo para o próximo turno"
        };
    }
    public void DontFinishWork(){
        cheif = new List<string>(){ 
            // Não terminou:
            "Se quiser ser pago é melhor trabalhar direito",
            "Continue assim e não precisará voltar amanhã.",
            "Volte logo para o próximo turno"
        };
    }
    public void DontStamina(){
        cheif = new List<string>(){ 
            // Não terminou:
            "Fingindo estar cansado?",
            "Acha que temos tempo de esperar que queira trabalhar?",
            "Se for continuar assim, esqueça teu salário",
            "Vá antes que eu mude de ideia, e venha logo para o próximo turno"
        };
    }
    public void ChefOrders(){
        cheif = new List<string>(){ 
            // Ao falar com o chefe de equipe para iniciar o trabalho:
            "Vá dormir na tua barraca que amanhã terá mais trabalho",
        };
    }
    public void DontFinshWork(){
        cheif = new List<string>(){ 
            // Ao terminar o trabalho:
            // Trabalho não feito:
            "Se quiser ser pago é melhor trabalhar direito.",
            "Continue assim e nem precisa voltar amanhã."
        };
    }
    public void SpecialNight1(){
        workerSpecial = new List<string>(){
         // Noite 1:
        "Ah, Álcool, uma das melhores coisas inventadas.",
        "Como podem proibir-nos algo tão bom? Isto é o que me faz mais produtivo! Como esperam que viva sem?",
        "Nós não devíamos continuar a aguentar estas regras sem sentido."
        };
    }
    public void SpecialNight2(){
        workerSpecial = new List<string>(){
        // Noite 2:
            "Você voltou! Estávamos discutindo o plano.",
            "O que acha de ganhar um pouco mais? Dinheiro sempre é bom!",
            "Borracha em alta, poder comprar armas e sair da ferrovia. O que acha?",
            "Estando de acordo, sairemos daqui na próxima noite em que nos encontrarmos, depois de uma bebida final."
        };
    }
    public void SpecialNight3(){
        workerSpecial = new List<string>(){
            // Noite 12:
            "Ao seringueiro! Não vai se arrepender."
        };
    }
    public void Rejected(){
        workerSpecial = new List<string>(){
            // resposta errada:
            "Se adoras tanto esta Companhia, por que sempre volta aqui?"
        };
    }
    public void InitializeWorkerTalkDay1(){
        workerTalkDay1[0] = new List<string>{// Dia 1
            "Mais um dia, mais trabalho.",
            "Quando este ciclo acabará?"
            };
        workerTalkDay1[1] = new List<string>{// Dia 1
            "Uuhhh este trabalho ainda vai matar-me.",
            "Seria bom sair em férias..."
            };
        workerTalkDay1[2] = new List<string>{// Dia 1
            "Meu sangue deve ser muito bom.",
            "Esta maldita floresta está cheia de mosquitos.",
            "E estão usando-me de almoço."
            };
        workerTalkDay1[3] = new List<string>{
            // Dia 1
            "Eimai kourasmenos."
            };
         workerTalkDay1[5]= new List<string>(){
            // Dia 1:
            "Uma bebida seria boa agora."
        };
        worker0AnswerPositive = new List<string>(){
            //P: Nunca.
            "Haha você tá certo, só quando morrermos seremos livres."

        };
        worker0AnswerNegative = new List<string>(){
            // Protagonista: Quando a ferrovia estiver pronta.
            "Isto só até arranjarmos outro emprego tão ruim quanto."
        };
        playerAnswers[0] = new List<string>{
            "Quando a ferrovia estiver pronta.",
            "Nunca."
        };
        playerAnswers[5] = new List<string>{
            "Talvez as regras tenham motivo.",
            "Não aguento mais estas regras."
        };
    }
    public void InitializeWorkerTalkDay2(){
        workerTalkDay2[0] = new List<string>{// Dia 2: o jogo assume seu ritmo normal e as escolhas noturnas são desbloqueadas.
            "Ei, Burro de Carga, você vem jogar poker hoje?",
            "Nada aqui tem muito sentido sem umas apostas de vez em quando."
            };
        workerTalkDay2[1] = new List<string>{ // Dia 2
            "Ouvi que demitiram alguns trabalhadores por não serem “eficientes o suficiente”.",
            "Talvez se este lugar não fosse um inferno seriamos mais produtivos."
            };
        workerTalkDay2[2] = new List<string>{// Dia 2
            "Ei! Cuidado onde anda, esta mata está cheia de mosquitos."
            };
        workerTalkDay2[3] = new List<string>{// Dia 2
            "The theleis?"
            };
        workerTalkDay2[5]= new List<string>(){
            // Dia 1:
            "Não vá dormir cedo hoje!",
            "Encontre-nos de noite.",
            "*sussurrando* Haverá bebidas."
        };
        worker0AnswerPositive = new List<string>(){
            // P: Sim.
            "É assim que há de ser! Espero-te lá, amigo."

        };
        worker0AnswerNegative = new List<string>(){
             // P: Não.
            "Pois está perdendo a melhor parte deste lugar."
        };
        playerAnswers[0] = new List<string>{
            "Não.",
            "Sim."
        };
        
    }
    public void InitializeWorkerTalkDay12(){
        workerTalkDay12[0] = new List<string>{// Dia 12: Alguns trabalhadores parecem doentes. Esse dia serve como uma introdução às condições ruins de saúde.
            "Aqueles senhores não parecem bem.",
            "Quanto tempo ainda aguentarão?",
            "E quanto tempo até os substituírem?"
            };
        workerTalkDay12[1] = new List<string>{// Dia 12
            "Quantos doentes.",
            "Deve ser culpa destas barracas.",
            "Certas regiões da ferrovia têm casas, mas nós temos apenas estas barracas de lona."
            };
        workerTalkDay12[2] = new List<string>{ // Dia 12
            "Não...posso parar...",
            // P: Você tá bem?
            "Sinto-me doente.",
            "O dia poderia... acabar mais rápido.",
            };
        workerTalkDay12[3] = new List<string>{// Dia 12
            "Echo pyreto. Chreiazomai giatro."
            };
        playerAnswers[2] = new List<string>{
            "Talvez devesse parar.",
            "...",
            "Você está bem?"
        };
        workerTalkDay12[5]= new List<string>(){
            // Dia 1:
            "Você vem hoje à noite?",
            "Apenas traga alguns trocados e poderá beber o quanto quiser."
        };
    }
    public void InitializeWorkerTalkDay20(){
        workerTalkDay20[0] = new List<string>{// Dia 20: Um novo grupo de trabalhadores chega, demonstrando a constante circulação de novos trabalhadores para substituir os antigos.
            // O novo grupo de trabalhadores é composto por estrangeiros, assim tendo suas 
            // falas incompreensivas (como do Trabalhador 4) e geram uma sensação maior de estranheza, desconhecido e isolamento.
            "Um trabalhador novo, sabe o que significa?",
            "Os outros hão de ter morrido.",
            "Logo nós iremos, é impossível ficar muito tempo vivo neste lugar.",
            "E isto tudo pelo quê?",
            };
        workerTalkDay20[1] = new List<string>{// Dia 20
            "Na última noite fui roubado, colocaram uma arma em minha cabeça e levaram todo o dinheiro..."
            };
        workerTalkDay20[4] = new List<string>{// Dia 20: 
            "É bom estar em lugar diferente, venho contente.",
            "Já estava enlouquecendo. "
        };
         workerTalkDay20[5]= new List<string>(){// Dia 20:
            "Um capataz acusou-me de estar bebendo no trabalho.",
            "Por sorte desistiu de falar com os punhos.",
        };
        worker0AnswerPositive = new List<string>(){
            // P: Pelo dinheiro.
            "Quanta morte e trabalho apenas por dinheiro... "
        };
        worker0AnswerNegative = new List<string>(){
            // P: Pela ferrovia.
            "Você realmente acredita na importância deste trabalho?",
            "Eu duvido de tudo que contam-nos."
        };
        playerAnswers[0] = new List<string>{
            "Pela ferrovia.",
            "Pelo dinheiro"
        };
    }
    public void InitializeWorkerTalkDay22(){
        workerTalkDay22[0] = new List<string>{// Dia 22: Nesse dia o Trabalhador 1 foge floresta adentro, tentando voltar para sua casa.
            // Esse dia dá a possibilidade do jogador tentar fugir e assim alcançar um final alternativo.
            "Você já pensou em tentar voltar pra casa?",
            "Eu não aguento mais ficar aqui, cansei disto tudo. Quero apenas ver minha família novamente.",
            "*sussurrando* Hoje à noite fugirei, prefiro tentar a sorte nesta mata a ficar mais um dia neste inferno.",
            "Deseje-me sorte",
            "Vejo-te do outro lado, amigo."
            };
        workerTalkDay22[4] = new List<string>{// Dia 20: 
            "Por que proíbem mulheres de aproximarem-se?",
            "Sei que não são fortes e não servem para ferrovia, mas servem a outras funções."
        };
         workerTalkDay22[5]= new List<string>(){// Dia 22:
            "Um grupo foi buscar algumas garrafas na vizinhança...",
            "Espero que retornem logo."
        };
        worker0AnswerPositive = new List<string>(){
             // P: Sim.
            "Então deve entender-me.",
            "Mas é difícil deixar este lugar com tantos capatazes.",
            "Ainda assim, preciso tentar."
        };
        worker0AnswerNegative = new List<string>(){
            // P: Não.
            "Nunca? Invejo-o...",
            "Queria eu ser despreocupado assim."
        };
        playerAnswers[0] = new List<string>{
            "Não.",
            "Sim.",
        };
        playerAnswers[3] = new List<string>{
            "Boa sorte.",
            "Mas é muito perigoso"
        };
    }
    public void InitializeWorkerTalkDay25(){
        workerTalkDay25[4] = new List<string>{// Dia 25: Ocorre um deslizamento durante a noite anterior,
            // fazendo com que parte dos trilhos seja destruída. Isso faz com que o jogador tenha que realizar o Trabalho B para arrumar os trilhos.
            "Ao menos não fui eu quem cortou as árvores no caminho do trilho.",
            "Hei de fazer este trabalho pela primeira vez, e não pela segunda."
            };
         workerTalkDay25[5]= new List<string>(){// Dia 25:
            "As árvores cairam? Demorou para acontecer...",
            "Toda vez que chove forte caem pela floresta."
        };
    }
    public void InitializeWorkerTalkDay26(){
        workerTalkDay26[4] = new List<string>{// Dia 26: O conserto dos trilhos é finalizado neste dia,
            // fazendo com que o jogador trabalhe durante a noite ao invés de escolher o que fazer. 
            // (Durante o dia realizaria o Trabalho B e de noite o Trabalho A, para compensar o tempo que o trem teria ficado parado).
            // Este também é o dia em que o jogador começa a ter sintomas da malária.
            "Penso que vão fazer-nos trabalhar além do anoitecer...",
            "Maldita chuva."
            };
         workerTalkDay26[5]= new List<string>(){// Dia 26:
            "É melhor não me obrigarem a trabalhar de noite.",
        };
    }
    public void InitializeWorkerTalkDay27(){
        workerTalkDay27[4] = new List<string>{ // Dia 27: Os sintomas do jogador pioram, tornando o trabalho ainda mais difícil.
            "Tá se sentindo bem?",
            "Ainda aguenta depois de ontem?"
            };
         workerTalkDay27[5] = new List<string>(){// Dia 27:
            "Ei, acho que você deveria descansar.",
            "Parece mal a ponto que uma garrafa inteira não resolveria."
        };
        playerAnswers[0] = new List<string>{
            "Está tudo bem.",
            "Talvez esteja doente."
        };
    }
}
