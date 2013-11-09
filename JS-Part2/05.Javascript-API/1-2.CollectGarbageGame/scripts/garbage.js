var collectGarbageGame = (function () {

    var ITEMS_TOTAL = 10;
    var FIELD_ID = "field";

    var TRASH_TOP = 10;
    var TRASH_LEFT = 30;
    var TRASH_CLOSED_IMAGE = "images/trashClosed.png";
    var TRASH_OPENED_IMAGE = "images/trashOpened.png";

    var MIN_TOP = 10;
    var MIN_LEFT = 300;
    var MAX_TOP = screen.height - 300;
    var MAX_LEFT = screen.width - 400;

    var TOP_SCORES_TO_KEEP = 5;

    var startTime = new Date();
    var itemsCount = 0;

    var images = [
        "images/water_bottle.png",
        "images/crushed_bottle.png",
        "images/plastic_flask.png",
        "images/plastic_littre.png",
        "images/crushed_bottle_small.png",
        "images/cap_red.png",
        "images/cap_blue.png",
        "images/cap_white.png"
    ];

    // Returns a random integer between min and max
    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function createItem(minTop, minLeft, maxTop, maxLeft) {

        var item = document.createElement("img");
        item.id = "item" + (itemsCount - 1);

        // set the screen position
        item.style.position = "absolute";

        var top = getRandomInt(minTop, maxTop);
        item.style.top = top + "px";

        var left = getRandomInt(minLeft, maxLeft);
        item.style.left = left + "px";

        item.setAttribute("draggable", "true");

        var imageIndex = getRandomInt(0, images.length - 1);
        item.src = images[imageIndex];

        if (item.addEventListener) {
            item.addEventListener("dragstart", dragItem, false);
        } else {
            item.attachEvent("ondragstart", dragItem);
        }

        return item;
    }

    function dragItem(event) {
        // ensure the event object is defined
        if (!event) event = window.event;
        var eventSource = (event.target ? event.target : event.srcElement);

        event.dataTransfer.setData("dragged-item-id", eventSource.id);
    }

    function dropItem(event) {
        // ensure the event object is defined
        if (!event) event = window.event;
        if (event.preventDefault) {
            event.preventDefault();
        }

        var eventSource = (event.target ? event.target : event.srcElement);

        if (event.clientX >= TRASH_LEFT + eventSource.clientWidth / 2 &&
            event.clientY <= TRASH_TOP + eventSource.clientHeight / 3) {

            var itemId = event.dataTransfer.getData("dragged-item-id");
            var item = document.getElementById(itemId);
            item.parentElement.removeChild(item);
            eventSource.src = TRASH_CLOSED_IMAGE;

            itemsCount--;

            if (itemsCount === 0) {
                finishGame();
            }
        } else {
            eventSource.src = TRASH_CLOSED_IMAGE;
        }
    }

    function allowDropItem(event) {
        // ensure the event object is defined
        if (!event) event = window.event;
        var eventSource = (event.target ? event.target : event.srcElement);

        if (event.clientX >= TRASH_LEFT + eventSource.clientWidth / 2 &&
            event.clientY <= TRASH_TOP + eventSource.clientHeight / 3) {

            eventSource.src = TRASH_OPENED_IMAGE;
        }

        if (event.preventDefault) {
            event.preventDefault();
        }
    }

    function restoreState(event) {
        // ensure the event object is defined
        if (!event) event = window.event;
        var eventSource = (event.target ? event.target : event.srcElement);
        eventSource.src = TRASH_CLOSED_IMAGE;

        if (event.preventDefault) {
            event.preventDefault();
        }
    }

    function finishGame() {
        var endTime = new Date();
        // get the time spent gathering the items
        var milliseconds = endTime.getTime() - startTime.getTime();
        var score = milliseconds / 1000;

        var nickname = prompt("Your score (sec): " + score + "\r\nPlease enter your nickname");

        localStorage.setItem(nickname ? nickname : "[anonymous]", score);

        if (localStorage.length > TOP_SCORES_TO_KEEP) {

            var worstScore = 0;
            var worstNickname;
            for (var i = 0; i < localStorage.length; i++) {

                var key = localStorage.key(i);
                var value = Number(localStorage.getItem(key));

                if (value > worstScore) {
                    worstScore = value;
                    worstNickname = key;
                }
            }

            localStorage.removeItem(worstNickname);
        }

        loadGame();
    }

    function addTrash() {
        var trash = document.createElement("img");
        trash.src = TRASH_CLOSED_IMAGE;

        trash.style.position = "absolute";
        trash.style.top = TRASH_TOP + "px";
        trash.style.left = TRASH_LEFT + "px";

        if (trash.addEventListener) {
            trash.addEventListener("drop", dropItem, false);
        } else {
            trash.attachEvent("ondrop", dropItem);
        }

        if (trash.addEventListener) {
            trash.addEventListener("dragover", allowDropItem, false);
        } else {
            trash.attachEvent("ondragover", allowDropItem);
        }

        if (trash.addEventListener) {
            trash.addEventListener("dragleave", restoreState, false);
        } else {
            trash.attachEvent("ondragleave", restoreState);
        }

        var field = document.getElementById(FIELD_ID);
        field.appendChild(trash);
    }

    function addItem() {
        itemsCount++;

        var field = document.getElementById(FIELD_ID);
        var item = createItem(MIN_TOP, MIN_LEFT, MAX_TOP, MAX_LEFT);
        field.appendChild(item);
    }

    // creates a table which contains the top scoring players
    // this data is kept in the local storage
    function displayTopScores() {

        var localStorageArray = [];

        if (localStorage.length && localStorage.length > 0) {

            for (var i = 0; i < localStorage.length; i++) {

                var key = localStorage.key(i);
                var value = Number(localStorage.getItem(key));

                localStorageArray.push({ key: key, value: value });
            }

            localStorageArray.sort(function (kvp1, kvp2) {
                return kvp1.value - kvp2.value;
            });
        }

        var table = document.createElement("table");
        table.style.margin = "auto";

        if (localStorageArray.length > 0) {

            var tableHeader = document.createElement("thead");
            tableHeader.innerHTML =
                "<thead>" +
                "<tr><th colspan='2'>TOP PLAYERS</th></tr>" +
                "<tr><th>NICKNAME</th><th>SCORE (SEC)</th></tr>" +
                "</thead>";
            table.appendChild(tableHeader);
        }

        for (var j = 0; j < localStorageArray.length; j++) {

            var row = document.createElement("tr");
            row.innerHTML =
                "<td><strong>" + localStorageArray[j].key + "</strong></td>" +
                "<td>" + localStorageArray[j].value + "</td>";
            table.appendChild(row);
        }

        var tableFooter = document.createElement("tfoot");
        var footerRow = document.createElement("tr");
        var footerCell = document.createElement("td");
        footerCell.setAttribute("colspan", "2");
        var startButton = document.createElement("button");
        startButton.innerHTML = "Start Game";
        startButton.style.width = "100%";

        // attach click event handler
        if (startButton.addEventListener) {
            startButton.addEventListener("click", startGame, false);
        } else {
            startButton.attachEvent("onclick", startGame);
        }

        footerCell.appendChild(startButton);
        footerRow.appendChild(footerCell);
        tableFooter.appendChild(footerRow);
        table.appendChild(tableFooter);

        var field = document.getElementById(FIELD_ID);
        field.appendChild(table);
    }

    function loadGame() {
        var field = document.getElementById(FIELD_ID);
        // clear field
        while (field.firstChild) {
            field.removeChild(field.firstChild);
        }

        displayTopScores();
    }

    function startGame() {
        var field = document.getElementById(FIELD_ID);
        // clear field
        field.removeChild(document.querySelector("table"));

        addTrash();

        for (var i = 0; i < ITEMS_TOTAL; i++) {
            addItem();
        }

        // start the timer
        startTime = new Date();
    }

    return {
        loadGame: loadGame
    };
})();