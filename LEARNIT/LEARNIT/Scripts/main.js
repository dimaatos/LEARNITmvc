var genres = { 28: "Action", 12: "Adventure", 16: "Animation", 35: "Comedy", 80: "Crime", 99: "Documentary", 18: "Drama", 10751: "Family", 14: "Fantasy", 10769: "Foreign", 36: "History", 27: "Horror", 10402: "Music", 9648: "Mystery", 10749: "Romance", 878: "Science Fiction", 10770: "TV Movie", 53: "Thriller", 10752: "War", 37: "Western" }

$(document).ready(function () {
    $("span[data-genre]").each(function () {
        var genre = $(this).data('genre');
        $(this).text(genres[genre]);
    });

    $.each(genres, function (id, name) {
        $(".genres").append("<a href='/Search/Genre/" + id + "'>" + name + "</a>")
    });
});

function getGenre(id) {
    return genres[id];
}

var isLoading = false;

function throttle(func, wait) {
    var timeout;
    return function () {
        var context = this, args = arguments;
        if (!timeout) {
            timeout = setTimeout(function () {
                timeout = null;
                func.apply(context, args);
            }, wait);
        }
    }
}

    function kindaLazy(scroller, container, element) {
        scroller.bind("scroll", throttle(function () {
            var lazyPos = element.offset().top + element.outerHeight();
            var x = $(window).scrollTop() + $(window).height();
            if (x >= lazyPos && !isLoading) {
                dataLoad(container, false);
                isLoading = true;
            }
        }, 250));

    }

    function bindClicks(items) {
        $(items).bind("click", function (e) {
            var weActive =! $(this).hasClass("active");
            $(items + ".active").not(this).removeClass("active");
            if (weActive) {
                $(this).addClass("active");
            }
        });
    }

    // PARAMETERS:
    // container = Container to append items to, must have the correct data attributes.
    // container data attributes:
    //      data-action = the search action (discover, search)
    //      data-query = if the action is search and we are appending new elements, this is the search query
    //      data-page = The current page of data we are loading
    // init = true: new "load", empties container, resets page to 1. false: appends items to an existing "load"
    // element = in case of search, this is the search input, otherwise should be null.
    // scrollElement = the element that lazy-load will check for the scroll event (default = $(window))
    function dataLoad(container, init, element, scrollElement) {
        var url,
            lazyElement,
            query,
            type,
            id,
            page,
            ajData = {},
            action = container.attr("data-action");

        if (scrollElement === undefined) {
            scrollElement = $(window);
        }

        console.log(action);

        switch (action) {
            case "search":
                url = "/Data/Search";
                if (init) {
                    type = element.val().trim();
                    container.attr("data-query", type);
                } else {
                    type = container.attr("data-query");
                }

                if (/\S/.test(type)) {
                    ajData.query = encodeURIComponent(type);
                } else {
                    console.log("query blank or invalid")
                    return false;
                }
                scrollElement = $(window);
                break;
            case "discover":
                url = "/Data/Discover";
                type = container.attr("data-type");
                ajData.type = type.toLowerCase();
                break;
            case "genre":
                url = "/Data/Genre";
                ajData.genreId = container.attr("data-type");
                type = getGenre(container.attr("data-type"));
                break;
            default:
                console.log("action invalid");
                return false;
        }

        if (!init) {
            page = container.attr("data-page");
        } else {
            type = type.substr(0, 1).toUpperCase() + type.substr(1);
            var title = (action === "search")
                ? "Results for \"" + type + "\""
                : type + " Movies";
            $("#results-title").html(title);
            container.empty();
            page = 0;
        }
        page++;
        container.attr("data-page", page);

        ajData.page = page;

        $.ajax({
            method: "GET",
            url: url,
            data: ajData,
            dataType: "html"
        }).success(function (data) {
            scrollElement.unbind("scroll");
            if (!data.trim()) {
                if (action === "search" && init) {
                    $('.filter-error').append('<span>No results found :(</span>').fadeIn('250');
                } else if (!init) {
                    scrollElement.unbind("scroll");
                } else {
                    console.log("something went wrong with " + data.toString());
                }
            } else {
                container.append(data);
                $("#" + container.attr("id") + " .genre").each(function () {
                    $(this).html(getGenre($(this).attr("data-genre")));
                });
                $(".lazy").removeClass("lazy");
                lazyElement = container.children().last();
                lazyElement.addClass("lazy");
                isLoading = false;
                kindaLazy(scrollElement, container, lazyElement);
                bindClicks(".item");
            }
        });
        console.log("Success!");
        console.log(url);
        console.log(ajData);
        return false;
    }
