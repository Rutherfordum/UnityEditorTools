# UnityEditorTools

## Описание
UnityEditorTools - это набор инструментов способный автоматизировать рутинные задачи для ускорения разработки. На данный момнет он содержит два инструмента по генерации классов с данными Addressables и AnimatorController. 

AnimatorToolEditor  - это инструмент для создания класс с свойствами AnimatorController. Он упращает жизнь когда у вас очень много свойств в аниматоре и сокращает время на создания класса в ручную.

AddressablesToolEditor  - это инструмент для создания класс с свойствами(ключами) AddressablesGroup. Он упращает жизнь когда у вас очень много обьектов в AddressablesGroup и сокращает время на создания класса с ключами для их загрузки.

## Порядок установки
Есть два варанта:
Первый, скачать нужный пакет *.unitypackage из [releases](https://github.com/Rutherfordum/UnityEditorTools/releases) и добавить в свой проект.
Второй, установка через Unity Package Manager / Add package from git URL: https://github.com/Rutherfordum/UnityEditorTools

## Как пользоваться AnimatorToolEditor
Выберите свой `AnimatorControoler` правой кнопкой мыши, в раскрывающемся меню выберите `Generate Class From AnimatorController` 

Пример использования AnimatorToolEditor
![Alt Text](https://github.com/Rutherfordum/UnityAnimatorTools/blob/main/VideoResources/2024-04-26-17-51-33.gif)

## Как пользоваться AddressablesToolEditor
Установите пакет Addressables из менеджера пакетов Unity, выберите вкладку `Tools/Addressables/Generate Classes From Addressables Group свой` после чего автоматический сгенерируется класс с ключами AdressablesGroup 
