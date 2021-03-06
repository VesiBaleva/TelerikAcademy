﻿var ui = (function () {

	function buildLoginForm() {
		var html =
            '<div id="login-form-holder">' +
				'<form>' +
					'<div id="login-form">' +
						'<label for="tb-login-username">Username: </label>' +
						'<input type="text" id="tb-login-username"><br />' +
						'<label for="tb-login-password">Password: </label>' +
						'<input type="password" id="tb-login-password"><br />' +
						'<button id="btn-login" class="button">Login</button>' +
					'</div>' +
					'<div id="register-form" style="display: none">' +
						'<label for="tb-register-username">Username: </label>' +
						'<input type="text" id="tb-register-username"><br />' +
						'<label for="tb-register-nickname">Nickname: </label>' +
						'<input type="text" id="tb-register-nickname"><br />' +
						'<label for="tb-register-password">Password: </label>' +
						'<input type="password" id="tb-register-password"><br />' +
						'<button id="btn-register" class="button">Register</button>' +
					'</div>' +
					'<a href="#" id="btn-show-login" class="button selected">Login</a>' +
					'<a href="#" id="btn-show-register" class="button">Register</a>' +
				'</form>' +
				'<div id="error-messages"></div>' +
            '</div>';
		return html;
	}

	function buildGameUI(nickname) {
		var html = '<span id="user-nickname">' +
				nickname +
		'</span>' +
		'<button id="btn-logout">Logout</button><br/>' +
		'<div id="create-game-holder">' +
			'Title: <input type="text" id="tb-create-title" />' +
			'Password: <input type="password" id="tb-create-pass" />' +
			'<button id="btn-create-game">Create</button>'  +
			'<div id="error-messages"></div>' +
		'</div>' +
		'<div id="open-games-container">' +
			'<h2>Open</h2>' +
			'<div id="open-games"></div>' +
		'</div>' +
		'<div id="active-games-container">' +
			'<h2>Active</h2>' +
			'<div id="active-games"></div>' +
		'</div>' +
		'<div id="game-holder">' +
		'</div>' +
		'<div id="messages-holder">' +
		'</div>';
		return html;
	}

	function buildOpenGamesList(games) {
	    var list = '<ul class="game-list open-games">';
		for (var i = 0; i < games.length; i++) {
			var game = games[i];
			list +=
				'<li data-game-id="' + game.id + '">' +
					'<a href="#" >' +
						$("<div />").html(game.title).text() +
					'</a>' +
                    '<span> by ' +
						game.creator +
					'</span>' +
				'</li>';
		}
		list += "</ul>";
		return list;
	}

	function buildActiveGamesList(games) {
		var gamesList = Array.prototype.slice.call(games, 0);
		gamesList.sort(function (g1, g2) {
			if (g1.status == g2.status) {
				return g1.title > g2.title;
			}
			else {
				if (g1.status == "in-progress") {
					return -1;
				}
			}
			return 1;
		});

		var list = '<ul class="game-list active-games">';
		for (var i = 0; i < gamesList.length; i++) {
			var game = gamesList[i];
			list +=
				'<li class="game-status-' + game.status + '" data-game-id="' + game.id + '" data-creator="' + game.creator + '">' +
					'<a href="#" class="btn-active-game">' +
						$("<div />").html(game.title).text() +
					'</a>' +
                    '<span> by ' +
                        $("<div />").html(game.creator).text() +
					'</span>' +
				'</li>';
		}
		list += "</ul>";
		return list;
	}

	function buildBattleTable(battles) {
	    
		var tableHtml =
			'<table border="1" cellspacing="0" cellpadding="5">' +
				'<tr>' +
					'<th>Number</th>' +
					'<th>Cows</th>' +
					'<th>Bulls</th>' +
				'</tr>';
		for (var i = 0; i < battles.length; i++) {
			var battle = battles[i];
			tableHtml +=
				'<tr>' +
					'<td>' +
						battle.nickname +
                    '</td>'
				'</tr>';
		}
		tableHtml += '</table>';
		return tableHtml;
	}

	function buildGameField(gameField) {
		var html =
			'<div id="game-field" data-game-id="' + game.id + '">' +
				'<h2>' + gameField.title + '</h2>' +
				'<div id="blue-battles" class="battle-holder">' +
					'<h3>' +
						gameField.blue + '\'s ' +
					'</h3>' +
					buildBattleTable(gameField.blue) +
				'</div>' +
				'<div id="red-battles" class="battle-holder">' +
					'<h3>' +
						gameField.red + '\'s ' +
					'</h3>' +
					buildBattleTable(gameField.red) +
				'</div>' +
		'</div>';
		return html;
	}
	
	function buildMessagesList(messages) {
		var list = '<ul class="messages-list">';
		var msg;
		for (var i = 0; i < messages.length; i += 1) {
			msg = messages[i];
			var item =
				'<li>' +
					'<a href="#" class="message-state-' + msg.state + '">' +
						msg.text +
					'</a>' +
				'</li>';
			list += item;
		}
		list += '</ul>';
		return list;
	}

	return {
		gameUI: buildGameUI,
		openGamesList: buildOpenGamesList,
		loginForm: buildLoginForm,
		activeGamesList: buildActiveGamesList,
		gameField: buildGameField,
		messagesList: buildMessagesList
	}

}());