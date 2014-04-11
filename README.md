DragonBonesUnity
=======================
DragonBones Library Unity version

目录说明：
=======================
DragonBones: C#版DragonBones实现  
Com: 某些DragonBones需要的辅助类的C#实现，例如Event, Matrix, JSON等。  
BirdAndCentaurDemo: 一个Untiy3D 4.3项目, 演示了DragonBones骨骼动画在Unity3D下的播放。   

源码结构：
=======================
DragonBones目录里, Display目录下是基于Unity3D的渲染实现, factory下面添加了UnityFactory以适配Unity3D的显示机制. 其他部分基于dragonBones 2.4版本的actionScript版本翻译过来，只是语言改成C#，算法部分没有任何改动。

Known Issues：
=======================
ColorTransform没有实现。  
骨骼的动态添加与删除以及骨骼z深度顺序动态更改还未经测试。  
子骨架未经测试。


