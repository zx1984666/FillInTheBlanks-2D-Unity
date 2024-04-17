# FillInTheBlanks-2D-Unity
基于Unity开发的选字填空小游戏
这是一个基于 Unity 引擎开发的小游戏项目框架，名为“选字填空”。该框架旨在为开发者提供一个快速搭建汉字填空游戏的基础结构，同时也为玩家提供了一种有趣的汉字学习和拼字游戏体验。

# 游戏简介
在“选字填空”游戏中，玩家需要通过将漂浮的汉字拖拽到底部的汉字框中，连接成正确的句子来完成关卡。汉字会在场景中随机漂浮，玩家需要根据提示找到正确的汉字，将它们拖拽到相应的位置。游戏设定了多个关卡，每个关卡都有不同的挑战和提示。

# 游戏场景
游戏场景分为三个主要模块：

漂浮汉字模块：场景中大量漂浮着的汉字，每一个汉字对应一个预制体：FloatingCharacter。

汉字框模块：场景底部存放汉字的框，每一个存放汉字的框对应一个预制体：CharacterSlot。
CharacterSlot如果勾选了IsFixed属性，那么就需要提前在该格子内填入需要的汉字，并且该格子将不会再受到任何交互的影响，无法取出汉字和存入汉字，汉字直接被固定住了

提示模块：提示按钮和提示页面，提示页面是一个 Panel，在点击提示按钮时打开：TipsPanel。

# 游戏内容
开发者需做
开发者需要手动编辑每一个关卡，包括设置场景中的汉字数量、汉字漂浮速度、汉字连接成正确答案语句等。这些设定选项都已在脚本中编写，开发者可以直接在可视化面板编辑。需要注意的是，场景中漂浮的汉字中一定要设定至少存在一个能连接成为正确答案语句的汉字，否则玩家无法通关。

玩家游玩内容
玩家进入游戏后，可以打开提示面板，查看当前关卡需要选择找到哪些汉字来拼接正确的语句。玩家通过拖拽漂浮的汉字到底部的汉字框中，连接成正确的语句即可通关进入下一关卡。汉字在场景中按照开发者设定的速度随机漂浮，当汉字触碰边界或者碰撞到其他文字时会弹开。

# 脚本说明
FloatingWordGamePage.cs
此脚本控制游戏页面的整体逻辑，包括切换关卡、检查通关条件等功能。

FloatingCharacter.cs
漂浮汉字的脚本，实现汉字的漂浮效果，拖拽功能等。

CharacterSlot.cs
汉字框的脚本，控制汉字放置和点击事件等功能。

# 使用说明
将相关脚本添加到 Unity 项目中。
根据游戏设计需要，编辑每个关卡的设定。
在场景中放置漂浮汉字和汉字框预制体。
调整场景布局和美观效果。
编译并运行游戏，享受游戏乐趣！
# 注意事项
确保每个关卡至少存在一个能连接成为正确答案语句的汉字，以保证玩家可以通关。
注意调整漂浮汉字的数量和速度，以确保游戏体验平衡。
# 版权信息
本项目遵循 MIT 开源许可协议，可自由使用、修改和分发，但需附上原始版权声明。
===========================================================================================================================================================================================================================
# FillInTheBlanks-2D-Unity
Based on Unity development of the word fill in the blanks game
This is a small game project framework based on Unity engine development, called "Fill in the blanks". The framework aims to provide an infrastructure for developers to quickly build Chinese character fill-in-the-blank games, as well as an interesting Chinese character learning and Scrabble game experience for players.

# About the game
In the "Fill in the Blank" game, the player needs to complete the level by dragging the floating Chinese characters into the Chinese character box at the bottom and connecting them into the correct sentence. The characters float randomly in the scene, and the player needs to follow the prompts to find the correct characters and drag them to the corresponding positions. The game has multiple levels, each with different challenges and prompts.

# Game scenario
The game scene is divided into three main modules:

Floating Chinese character module: A large number of Chinese characters are floating in the scene, and each Chinese character corresponds to a prefabricated body: FloatingCharacter.

Chinese character box module: The box storing Chinese characters at the bottom of the scene, and each box storing Chinese characters corresponds to a prefabricated body: CharacterSlot.
If the IsFixed property is checked, then the required Chinese characters need to be filled in the cell in advance, and the cell will not be affected by any interaction. The Chinese characters cannot be taken out or stored, and the Chinese characters are directly fixed

Tip module: Tip button and tip page, the tip page is a Panel that opens when the tip button is clicked: TipsPanel.

# Game Content
What developers need to do
Developers need to manually edit each level, including setting the number of characters in the scene, the speed at which they float, and the concatenation of Chinese characters into correct answer statements. These Settings have been written in the script, developers can directly edit in the visualization panel. It should be noted that there must be at least one Chinese character floating in the scene that can be connected to become the correct answer sentence, otherwise the player cannot complete the level.

Players play content
After entering the game, the player can open the prompt panel to see which Chinese characters need to be selected to find for the current level to splice the correct sentence. By dragging the floating Chinese characters to the bottom of the Chinese character box, the player can connect to the correct sentence to complete the level and enter the next level. Characters float around the scene at random speeds set by the developers, bouncing off when they touch a border or collide with other characters.

# Script description
FloatingWordGamePage.cs
This script controls the overall logic of the game page, including functions such as switching levels, checking conditions, and so on.

FloatingCharacter.cs
The script of floating Chinese characters, realize the floating effect of Chinese characters, drag and drop functions.

CharacterSlot.cs
Chinese character box script, control Chinese character placement and click events and other functions.

# Instructions
Add the relevant script to the Unity project.
Edit the Settings for each level as required by the game design.
Floating Chinese characters and preforms of Chinese character frames are placed in the scene.
Adjust the layout and aesthetics of the scene.
Build and run the game, and have fun!
# Considerations
Make sure that each level has at least one Chinese character that can be linked into a correct answer statement to ensure that the player can complete the level.
Pay attention to adjust the number and speed of floating characters to ensure a balanced game experience.
# Copyright information
This project is free to use, modify, and distribute under the MIT Open Source license, provided that the original copyright notice is attached.
