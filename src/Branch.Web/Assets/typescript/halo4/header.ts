/// <refrence path="../definitions/jquery.d.ts" />

interface RecentGame {
    Id: string;
	Result: string;
	ResultClass: string;
    GameMode: string;
    GameModeSlug: string;
    Gamertag: string;
	FeaturedStatValue: string;
	FeaturedStatName: string;
	Map: string;
	BaseMapName: string;
	BaseMapImageUrl: string;
	EndDate: string;
}

declare var RecentGames: RecentGame[];

window.onload = function() {
	var recentMatchIndex = 0;

	function cycleRecentGame() {
		if (window.innerWidth > 768) {
			var recentGame = RecentGames[recentMatchIndex];
            var newContent = '\
<strong class="' + recentGame.ResultClass + '">' + recentGame.Result + '</strong> \
playing <strong>' + recentGame.GameMode + '</strong> \
on <strong>' + recentGame.Map + '</strong>, <br /> \
with <strong>' + recentGame.FeaturedStatValue + '</strong> ' + recentGame.FeaturedStatName + ' <br /> \
<a class="alt date" href="/xbox/' + recentGame.Gamertag + '/halo-4/match/' + recentGame.GameModeSlug + '/' + recentGame.Id + '/"> \
    &raquo; on ' + recentGame.EndDate + ' \
</a> \
					';

			var elem = $("#recent-match-details");
			$('header.halo4-service-record').attr('style', 'background-image:url(' + recentGame.BaseMapImageUrl + ')')
			elem.fadeOut(600, function () {
				elem.html(newContent);
				elem.fadeIn(600);
			});

			if (recentMatchIndex + 1 >= RecentGames.length)
				recentMatchIndex = 0;
			else
				recentMatchIndex++;
		}
	}
	setInterval(cycleRecentGame, 6000);

	// Preload Images
	function preloadImages() {
		for (var i = 0; i < RecentGames.length; i++) {
			var image = new Image();
			image.src = RecentGames[i].BaseMapImageUrl;
		}
	};
	preloadImages();
};
