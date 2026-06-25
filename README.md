# 🚂 Madeira-Mamoré

> Jogo 3D de simulação desenvolvido em Unity

Um jogo de simulação em primeira pessoa ambientado na histórica Estrada de Ferro Madeira-Mamoré, onde o jogador assume o papel de um trabalhador ferroviário que precisa gerenciar tarefas diárias, carregar e descarregar cargas, lidar com minigames e sobreviver ao longo dos dias.

---

## 🎮 Sobre o Jogo

**Madeira-Mamoré** é um jogo 3D de simulação desenvolvido em Unity com Universal Render Pipeline (URP). O jogador explora um ambiente ferroviário histórico e executa tarefas que variam conforme o período do dia — manhã, tarde e noite — incluindo carregar caixas para trens, descarregar mercadorias, cortar árvores e interagir com personagens NPCs.

O jogo conta com sistema de dias, cutscenes, minigames e HUD para controle de stamina e informações do jogador.

---

## ✨ Funcionalidades

- **Sistema de dias e períodos** (`DaySystem`) — as tarefas e interações mudam conforme manhã, tarde, almoço e noite
- **Sistema de mãos em primeira pessoa** (`Hand.cs`) — o jogador interage com o mundo via raycast do centro da câmera
- **Carregar e transportar caixas** com sistema de lerp suave até a posição da mão
- **Entrega por cor e layer** — caixas são compatíveis com determinados depósitos/trens pelo seu layer e cor
- **4 minigames** integrados:
  - 🔨 **Hammer** — Cortar árvores com machado
  - 📦 **Carry** — Transportar pacotes
  - 🚃 **Discharge** — Descarregar o trem
  - ❓ **Quest** — Sistema de missões
- **Sistema de stamina** — ações custam stamina ao jogador
- **Diálogos com NPCs** (`MensageController`) — personagens têm falas ativadas por proximidade
- **Menu de comida** no período de almoço
- **HUD** com informações do jogador
- **Cutscenes** para narrativa
- **Sistema de áudio** com AudioMixer e efeitos sonoros por ação
- **Outline em shaders** para destacar objetos interagíveis

---

## 🛠️ Tecnologias

| Ferramenta | Uso |
|---|---|
| **Unity** | Engine principal (3D) |
| **C#** | Lógica e scripts do jogo |
| **Universal Render Pipeline (URP)** | Pipeline de renderização |
| **ShaderLab / HLSL** | Shaders customizados (outline, materiais) |
| **AudioMixer** | Gerenciamento de camadas de áudio |
| **TextMesh Pro** | Renderização de texto na UI |
| **Visual Studio** | IDE de desenvolvimento |

---

## 📁 Estrutura do Projeto

```
MadeiraMamore/
├── Assets/
│   ├── 3D Models/            # Modelos 3D do jogo
│   ├── AudioMixer/           # Configurações de mixagem de áudio
│   ├── CutScenes/            # Cenas cinemáticas
│   ├── DaySystem/            # Sistema de dias e períodos do dia
│   ├── Fire/                 # Efeitos de fogo (partículas/shaders)
│   ├── HUD/                  # Interface do jogador
│   ├── Menu/                 # Telas de menu
│   ├── MiniGames/
│   │   ├── Carry/            # Minigame de transporte
│   │   ├── Discharge/        # Minigame de descarga do trem
│   │   ├── Hammer/           # Minigame de corte de árvore
│   │   ├── Objects/          # Objetos compartilhados dos minigames
│   │   └── Quest/            # Sistema de missões
│   ├── Musics and Sounds/    # Músicas e efeitos sonoros
│   ├── Player/
│   │   ├── Hand.cs           # Sistema de interação em primeira pessoa
│   │   ├── LimitPlayerWalk.cs # Limitação de área de movimentação
│   │   └── Cursor.png        # Cursor customizado
│   ├── Scenes/               # Cenas do jogo
│   ├── Settings/             # Configurações do projeto (URP)
│   ├── TMaterial/            # Materiais de terreno
│   ├── TextMesh Pro/         # Assets do TextMesh Pro
│   ├── characters/           # Assets dos personagens NPCs
│   ├── sharders/             # Shaders customizados
│   ├── Enter.cs              # Script de entrada/transição de cena
│   └── New Terrain.asset     # Terreno principal do jogo
├── Packages/
└── ProjectSettings/
```

---

## 🚀 Como Executar

### Pré-requisitos
- [Unity Hub](https://unity.com/download)
- Unity **2021.x** ou superior com **Universal Render Pipeline** (verificar versão em `ProjectSettings/ProjectVersion.txt`)

### Passos
1. Clone o repositório:
   ```bash
   git clone https://github.com/LuanWuu/Madeira-Mamor-.git
   ```
2. Abra o Unity Hub e clique em **Add project from disk**
3. Selecione a pasta `MadeiraMamore/`
4. Aguarde a importação dos assets e compilação dos shaders URP
5. Abra a cena principal em `Assets/Scenes/` e pressione **Play**

---

## 🕹️ Controles

| Ação | Controle |
|---|---|
| Mover | `WASD` |
| Interagir / Pegar objeto | `E` (Interactions) |
| Olhar | Mouse |

> O cursor fica travado no centro da tela durante o gameplay. A interação é baseada em raycast do centro da câmera.

---

## 🏗️ Arquitetura

O sistema central de interação é o `Hand.cs`, que controla tudo que o jogador pode fazer:

```csharp
// Raycast do centro da câmera detecta objetos por tag
void RaycastCheck() {
    Ray ray = Camera.main.ScreenPointToRay(screenCenter);
    if (Physics.Raycast(ray, out hit, distCanGet)) {
        switch(hit.collider.gameObject.tag) {
            case "Box":      // Pegar caixa
            case "Train":    // Entregar/descarregar trem
            case "Desposit": // Depositar carga
            case "Tree":     // Cortar árvore (minigame Hammer)
            case "Food":     // Abrir menu de comida (horário de almoço)
            case "Character":// Iniciar diálogo com NPC
        }
    }
}

// O comportamento muda conforme o período do dia
switch(DaySystem.dayTime) {
    case "Morning":   ControlerHadMorning();   break;
    case "Afternoon": ControlerHadAfternoon(); break;
}
```

O transporte de caixas usa **Lerp suave** para animar o objeto até a mão do jogador, depois `MoveTowards` para travá-lo na posição.

---

## 📅 Contexto Histórico

O jogo é inspirado na **Estrada de Ferro Madeira-Mamoré**, ferrovia construída entre 1907 e 1912 na região amazônica do Brasil (atual Rondônia). Conhecida como "Ferrovia do Diabo" pelo alto custo humano de sua construção, a linha tinha como objetivo escoar a borracha da Bolívia para o mercado internacional.

---

## 👥 Time

| Contribuidor | GitHub | Commits |
|---|---|---|
| Luan San An Wu | [@LuanWuu](https://github.com/LuanWuu) | 146 |
| Rodrigo Costa | [@Roddio44](https://github.com/Roddio44) | 22 |
| H1r0N | [@h1r0N](https://github.com/h1r0N) | 6 |
| Julliana Sales | [@decepcionada](https://github.com/decepcionada) | 3 |

---

## 📄 Licença

Este projeto foi desenvolvido para fins acadêmicos. Todos os direitos reservados aos autores.
