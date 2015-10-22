/// <refrence path="../definitions/jquery.d.ts" />
window.onload = function () {
    var recentMatchIndex = 0;
    function cycleRecentGame() {
        if (window.innerWidth > 768) {
            var recentGame = RecentGames[recentMatchIndex];
            var newContent = '\
<strong class="' + recentGame.ResultClass + '">' + recentGame.Result + '</strong> \
playing <strong>' + recentGame.GameMode + '</strong> \
on <strong>' + recentGame.Map + '</strong>, <br /> \
with <strong>' + recentGame.FeaturedStatValue + '</strong> ' + recentGame.FeaturedStatName + ' <br /> \
<span class="date">&raquo; on ' + recentGame.EndDate + '</span> \
					';
            var elem = $("#recent-match-details");
            $('.halo4-service-record').attr('style', 'background-image:url(' + recentGame.BaseMapImageUrl + ')');
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
    }
    ;
    preloadImages();
};

//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImhhbG80L2hlYWRlci50cyJdLCJuYW1lcyI6WyJjeWNsZVJlY2VudEdhbWUiLCJwcmVsb2FkSW1hZ2VzIl0sIm1hcHBpbmdzIjoiQUFBQSxrREFBa0Q7QUFnQmxELE1BQU0sQ0FBQyxNQUFNLEdBQUc7SUFDZixJQUFJLGdCQUFnQixHQUFHLENBQUMsQ0FBQztJQUV6QjtRQUNDQSxFQUFFQSxDQUFDQSxDQUFDQSxNQUFNQSxDQUFDQSxVQUFVQSxHQUFHQSxHQUFHQSxDQUFDQSxDQUFDQSxDQUFDQTtZQUM3QkEsSUFBSUEsVUFBVUEsR0FBR0EsV0FBV0EsQ0FBQ0EsZ0JBQWdCQSxDQUFDQSxDQUFDQTtZQUMvQ0EsSUFBSUEsVUFBVUEsR0FBR0E7Z0JBQ0pBLEdBQUdBLFVBQVVBLENBQUNBLFdBQVdBLEdBQUdBLElBQUlBLEdBQUdBLFVBQVVBLENBQUNBLE1BQU1BLEdBQUdBO2lCQUN0REEsR0FBR0EsVUFBVUEsQ0FBQ0EsUUFBUUEsR0FBR0E7WUFDOUJBLEdBQUdBLFVBQVVBLENBQUNBLEdBQUdBLEdBQUdBO2NBQ2xCQSxHQUFHQSxVQUFVQSxDQUFDQSxpQkFBaUJBLEdBQUdBLFlBQVlBLEdBQUdBLFVBQVVBLENBQUNBLGdCQUFnQkEsR0FBR0E7K0JBQzlEQSxHQUFHQSxVQUFVQSxDQUFDQSxPQUFPQSxHQUFHQTtNQUNqREEsQ0FBQ0E7WUFFSkEsSUFBSUEsSUFBSUEsR0FBR0EsQ0FBQ0EsQ0FBQ0EsdUJBQXVCQSxDQUFDQSxDQUFDQTtZQUN0Q0EsQ0FBQ0EsQ0FBQ0EsdUJBQXVCQSxDQUFDQSxDQUFDQSxJQUFJQSxDQUFDQSxPQUFPQSxFQUFFQSx1QkFBdUJBLEdBQUdBLFVBQVVBLENBQUNBLGVBQWVBLEdBQUdBLEdBQUdBLENBQUNBLENBQUFBO1lBQ3BHQSxJQUFJQSxDQUFDQSxPQUFPQSxDQUFDQSxHQUFHQSxFQUFFQTtnQkFDakIsSUFBSSxDQUFDLElBQUksQ0FBQyxVQUFVLENBQUMsQ0FBQztnQkFDdEIsSUFBSSxDQUFDLE1BQU0sQ0FBQyxHQUFHLENBQUMsQ0FBQztZQUNsQixDQUFDLENBQUNBLENBQUNBO1lBRUhBLEVBQUVBLENBQUNBLENBQUNBLGdCQUFnQkEsR0FBR0EsQ0FBQ0EsSUFBSUEsV0FBV0EsQ0FBQ0EsTUFBTUEsQ0FBQ0E7Z0JBQzlDQSxnQkFBZ0JBLEdBQUdBLENBQUNBLENBQUNBO1lBQ3RCQSxJQUFJQTtnQkFDSEEsZ0JBQWdCQSxFQUFFQSxDQUFDQTtRQUNyQkEsQ0FBQ0E7SUFDRkEsQ0FBQ0E7SUFDRCxXQUFXLENBQUMsZUFBZSxFQUFFLElBQUksQ0FBQyxDQUFDO0lBRW5DLGlCQUFpQjtJQUNqQjtRQUNDQyxHQUFHQSxDQUFDQSxDQUFDQSxHQUFHQSxDQUFDQSxDQUFDQSxHQUFHQSxDQUFDQSxFQUFFQSxDQUFDQSxHQUFHQSxXQUFXQSxDQUFDQSxNQUFNQSxFQUFFQSxDQUFDQSxFQUFFQSxFQUFFQSxDQUFDQTtZQUM3Q0EsSUFBSUEsS0FBS0EsR0FBR0EsSUFBSUEsS0FBS0EsRUFBRUEsQ0FBQ0E7WUFDeEJBLEtBQUtBLENBQUNBLEdBQUdBLEdBQUdBLFdBQVdBLENBQUNBLENBQUNBLENBQUNBLENBQUNBLGVBQWVBLENBQUNBO1FBQzVDQSxDQUFDQTtJQUNGQSxDQUFDQTtJQUFBLENBQUM7SUFDRixhQUFhLEVBQUUsQ0FBQztBQUNqQixDQUFDLENBQUMiLCJmaWxlIjoiaGFsbzQvaGVhZGVyLmpzIiwic291cmNlc0NvbnRlbnQiOlsiLy8vIDxyZWZyZW5jZSBwYXRoPVwiLi4vZGVmaW5pdGlvbnMvanF1ZXJ5LmQudHNcIiAvPlxyXG5cclxuaW50ZXJmYWNlIFJlY2VudEdhbWUge1xyXG5cdFJlc3VsdDogc3RyaW5nO1xyXG5cdFJlc3VsdENsYXNzOiBzdHJpbmc7XHJcblx0R2FtZU1vZGU6IHN0cmluZztcclxuXHRGZWF0dXJlZFN0YXRWYWx1ZTogc3RyaW5nO1xyXG5cdEZlYXR1cmVkU3RhdE5hbWU6IHN0cmluZztcclxuXHRNYXA6IHN0cmluZztcclxuXHRCYXNlTWFwTmFtZTogc3RyaW5nO1xyXG5cdEJhc2VNYXBJbWFnZVVybDogc3RyaW5nO1xyXG5cdEVuZERhdGU6IHN0cmluZztcclxufVxyXG5cclxuZGVjbGFyZSB2YXIgUmVjZW50R2FtZXM6IFJlY2VudEdhbWVbXTtcclxuXHJcbndpbmRvdy5vbmxvYWQgPSBmdW5jdGlvbigpIHtcclxuXHR2YXIgcmVjZW50TWF0Y2hJbmRleCA9IDA7XHJcblxyXG5cdGZ1bmN0aW9uIGN5Y2xlUmVjZW50R2FtZSgpIHtcclxuXHRcdGlmICh3aW5kb3cuaW5uZXJXaWR0aCA+IDc2OCkge1xyXG5cdFx0XHR2YXIgcmVjZW50R2FtZSA9IFJlY2VudEdhbWVzW3JlY2VudE1hdGNoSW5kZXhdO1xyXG5cdFx0XHR2YXIgbmV3Q29udGVudCA9ICdcXFxyXG48c3Ryb25nIGNsYXNzPVwiJyArIHJlY2VudEdhbWUuUmVzdWx0Q2xhc3MgKyAnXCI+JyArIHJlY2VudEdhbWUuUmVzdWx0ICsgJzwvc3Ryb25nPiBcXFxyXG5wbGF5aW5nIDxzdHJvbmc+JyArIHJlY2VudEdhbWUuR2FtZU1vZGUgKyAnPC9zdHJvbmc+IFxcXHJcbm9uIDxzdHJvbmc+JyArIHJlY2VudEdhbWUuTWFwICsgJzwvc3Ryb25nPiwgPGJyIC8+IFxcXHJcbndpdGggPHN0cm9uZz4nICsgcmVjZW50R2FtZS5GZWF0dXJlZFN0YXRWYWx1ZSArICc8L3N0cm9uZz4gJyArIHJlY2VudEdhbWUuRmVhdHVyZWRTdGF0TmFtZSArICcgPGJyIC8+IFxcXHJcbjxzcGFuIGNsYXNzPVwiZGF0ZVwiPiZyYXF1bzsgb24gJyArIHJlY2VudEdhbWUuRW5kRGF0ZSArICc8L3NwYW4+IFxcXHJcblx0XHRcdFx0XHQnO1xyXG5cclxuXHRcdFx0dmFyIGVsZW0gPSAkKFwiI3JlY2VudC1tYXRjaC1kZXRhaWxzXCIpO1xyXG5cdFx0XHQkKCcuaGFsbzQtc2VydmljZS1yZWNvcmQnKS5hdHRyKCdzdHlsZScsICdiYWNrZ3JvdW5kLWltYWdlOnVybCgnICsgcmVjZW50R2FtZS5CYXNlTWFwSW1hZ2VVcmwgKyAnKScpXHJcblx0XHRcdGVsZW0uZmFkZU91dCg2MDAsIGZ1bmN0aW9uICgpIHtcclxuXHRcdFx0XHRlbGVtLmh0bWwobmV3Q29udGVudCk7XHJcblx0XHRcdFx0ZWxlbS5mYWRlSW4oNjAwKTtcclxuXHRcdFx0fSk7XHJcblxyXG5cdFx0XHRpZiAocmVjZW50TWF0Y2hJbmRleCArIDEgPj0gUmVjZW50R2FtZXMubGVuZ3RoKVxyXG5cdFx0XHRcdHJlY2VudE1hdGNoSW5kZXggPSAwO1xyXG5cdFx0XHRlbHNlXHJcblx0XHRcdFx0cmVjZW50TWF0Y2hJbmRleCsrO1xyXG5cdFx0fVxyXG5cdH1cclxuXHRzZXRJbnRlcnZhbChjeWNsZVJlY2VudEdhbWUsIDYwMDApO1xyXG5cclxuXHQvLyBQcmVsb2FkIEltYWdlc1xyXG5cdGZ1bmN0aW9uIHByZWxvYWRJbWFnZXMoKSB7XHJcblx0XHRmb3IgKHZhciBpID0gMDsgaSA8IFJlY2VudEdhbWVzLmxlbmd0aDsgaSsrKSB7XHJcblx0XHRcdHZhciBpbWFnZSA9IG5ldyBJbWFnZSgpO1xyXG5cdFx0XHRpbWFnZS5zcmMgPSBSZWNlbnRHYW1lc1tpXS5CYXNlTWFwSW1hZ2VVcmw7XHJcblx0XHR9XHJcblx0fTtcclxuXHRwcmVsb2FkSW1hZ2VzKCk7XHJcbn07XHJcbiJdLCJzb3VyY2VSb290IjoiL3NvdXJjZS8ifQ==
