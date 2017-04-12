window.onload = function () {

    function Answer() {
        var textAnswer = []; //текст ответов
        var right = []; //правильные ответы
        var typeQ = ["radio", "checkbox"]; 
        var type = 0; //тип вопроса

        //чтение всех ответов
        function Read() {
            inputs = document.getElementsByName("AnswerText");

            for (i = 0; i < inputs.length; i++)
                textAnswer[textAnswer.length] = inputs[i].value;

            var radio = document.getElementsByName("IsRight");
            type = document.getElementsByName("TypeQuestion");
            type = type[0].checked ? 0 : 1;

            for (i = 0; i < radio.length; i++) 
                if (radio[i].checked)
                    right[right.length] = radio[i].value;
        }

        //загрузка обновленного списка ответов
        function Build() {
            str = "";

            for (i = 0; i < textAnswer.length; i++) {
                str += '<div>Текст ответа</div>' +
                    '<input type="text" name="AnswerText" value="' + textAnswer[i] + '"/>' +
                    '<input type=' + typeQ[type] + ' name="IsRight" value="' + i + '" />';
            }

            document.getElementById("answers").innerHTML = str;
        }

        //переустановка флага у ответов
        function SetChecked() {
            var radio = document.getElementsByName("IsRight");

            if (right.length == 0)
                radio[0].checked = true;
            else {
                for (i = 0; i < right.length; i++)
                    radio[right[i]].checked = true;
            }
        }

        //изменить тип вопроса
        this.Transform = function (val) {
            Read();
            type = val - 1;
            Build();
            SetChecked();
        }

        //добавить ответ
        this.Add = function () {
            Read();
            textAnswer[textAnswer.length] = "";
            Build();
            SetChecked();
        }

        //удалить ответ
        this.Delete = function () {
            Read();
            textAnswer.length -= textAnswer.length > 1 ? 1 : 0;
            Build();

            if (textAnswer.length == right[0]) right = [];

            SetChecked();
        }
    }

    if (document.getElementById("answers") != null) {
        document.getElementById("addAnswer").onclick = function () {
            var a = new Answer();
            a.Add();
        }


        document.getElementById("delAnswer").onclick = function () {
            var a = new Answer();
            a.Delete();
        }

        document.getElementById("typeQuestion").addEventListener('change', function (e) {
            var a = new Answer();
            a.Transform(e.target.value);
        });

        document.getElementById("endTest").addEventListener('click', function (e) {
            document.getElementById("formQuest").action = "/Tests/EndCreateTest";
        });
    }
}