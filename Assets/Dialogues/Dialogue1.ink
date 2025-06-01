# BG_0
# CHAR_0
VAR characterName = "Карина"
Привет, а ты кто, и где Влад?
~characterName = "Вы"
Привет. Я его новый сосед-стажер. А Влад… без понятия.
# CHAR_0
~characterName = "Карина"
Ясно. Ну я Карина, будем знакомы. Перваш значит?
~characterName = "Вы"
Угу.
# CHAR_0
~characterName = "Карина"
С какого направления?
~characterName = "Вы"
ПМИ.
# CHAR_0
~characterName = "Карина"
Так я тоже, если что нужно будет, обращайся.

# BG_1
# AUTHOR_TEXT
~characterName = ""
На следующих выходных в баре

# BG_2
~characterName = "Вы"
Привет.
# CHAR_0
~characterName = "Карина"
Угу.
~characterName = "Вы"
Ты чего такая грустная?
# CHAR_0
~characterName = "Карина"
Не твое дело.
    +[Отстать]
        -> answer1
    +[Попытаться разговорить]
        -> answer2

=== answer1 ===
# BG_1
# AUTHOR_TEXT
~characterName = ""
Не зная что делать, я пошел работать в бар
-> barDeal
=== answer2 ===
~characterName = "Вы"
Уоу, полегче.
# CHAR_0
~characterName = "Карина"
Прости. Просто… аргх…
~characterName = "Вы"
Может я могу чем-то помочь.
# CHAR_0
~characterName = "Карина"
…
~characterName = "Вы"
Да ладно, я никому не расскажу, если это личное.
# CHAR_0
~characterName = "Карина"
… Просто, он меня не замечает. А сейчас еще и ты, так не вовремя. Мы уже столько знакомы, неужели он ничего не замечает…
~characterName = "Вы"
Ничего не понимаю?
# CHAR_0
~characterName = "Карина"
Ну чего тут непонятного. Я о Владе.
~characterName = "Вы"
Оу. Неразделенные чувства…
# CHAR_0
~characterName = "Карина"
Я уже не знаю что делать…
    +[Предложить свою помощь]
    -> answer11
    +[Не лезть в чужие дела]
    -> answer12

=== answer11 ===
~characterName = "Вы"
Может мне как-то выведать у него, чувствует ли он к тебе что-то и в случае чего… подтолкнуть? Я же все-таки его сосед.
# CHAR_0
~characterName = "Карина"
Хм.
~characterName = "Вы"
Ну хуже уж точно не будет.
# CHAR_0
~characterName = "Карина"
Пожалуй ты прав, я буду тебе очень признательна.
# BG_1
# AUTHOR_TEXT
~characterName = ""
На следующий день в комнате
-> aboutKarina

=== answer12 ===
~characterName = "Вы"
Я тоже, я далек от всех этих любовных дел. Прости.
# CHAR_0
~characterName = "Карина"
Да тебе не за что извиняться.
# BG_1
# AUTHOR_TEXT
~characterName = ""
Через пару дней в баре
-> barDeal
=== nextChoice ===
# BG_3
# CHAR_0
~characterName = "Карина"
Ну что, как там наше маленькое дельце?
    +[Сказать правду про симпатию Влада]
        -> answer31
    +[Солгать, чтобы их пара не состоялась]
        -> answer32

=== answer31 ===
~characterName = "Вы"
В общем, ты ему не безразлична.
# CHAR_0
~characterName = "Карина"
УРА!!!
~characterName = "Вы"
Так что не переживай, думаю еще немного и он начнет действовать.
# CHAR_0
~characterName = "Карина"
Спасибо тебе огромное, я твоя должница.
# BG_1
# AUTHOR_TEXT
~characterName = ""
Я теперь сваха?
-> barDeal
=== answer32 ===
~characterName = "Вы"
В общем… не думаю что у вас что-то получится.
# BG_1
# AUTHOR_TEXT
~characterName = ""
Не быть вам Ларисой Гузеевой
-> barDeal

=== barDeal ===
# BG_2
# CHAR_1
~characterName = "Влад"
Ну что, как успехи?
~characterName = "Вы"
Ну вроде справляюсь.
# CHAR_1
~characterName = "Влад"
Клиенты в целом довольны, а это о многом говорит. Молодец, стажер!
~characterName = "Вы"
Хехе, спасибо.
# BG_1
# AUTHOR_TEXT
~characterName = ""
Ждите обновлений
->END
=== aboutKarina ===
# BG_4
~characterName = "Вы"
Влад.
# CHAR_1
~characterName = "Влад"
А?
~characterName = "Вы"
…тут есть одна девчонка, Карина.
# CHAR_1
~characterName = "Влад"
Что, понравилась?
~characterName = "Вы"
А что если и так?
# CHAR_1
~characterName = "Влад"
Закатай губу, она моя.
~characterName = "Вы"
О как. Понял.
# BG_1
# AUTHOR_TEXT
~characterName = ""
Через пару дней в коридорах общаги
-> nextChoice