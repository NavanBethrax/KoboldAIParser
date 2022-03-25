# KoboldAIParser

Features: 

* Open and edit saved KoboldAI sessions. 
* Convert .holo to .json files. (loadable by KoboldAI)
* Search session for names. (very basic)
* Search session for variables. (very basic)
* Global string replace function.
* Export/Import worldinfo as json files.

Important:
* You have to check game started for the prompt to be loaded the way it works now.
* If you compile the file yourself you have to create a "Prompts" and a "WorldInfo" folder for now.

There are little features that might change.
* The prompt is split and saved to actions for now. (i had problems with too large prompts)
* Worldinfo keys get always converted to lower.
* Worldinfo content automatically replaces new lines with space. (makes "[]" easier.)

![Preview](https://i.imgur.com/omh1ZJL.png)

Icon Source:
https://www.flaticon.com/de/kostenlose-icons/kobold
