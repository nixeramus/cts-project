(function (d) {
    d.fn.redirect = function (a, b, c) {
        void 0 !== c ? (c = c.toUpperCase(), "GET" != c && (c = "POST")) : c = "POST";
        if (void 0 === b || !1 == b) b = d().parse_url(a), a = b.url, b = b.params;
        var e = d("<form></form>");
        e.attr("method", c);
        e.attr("action", a);
        for (var f in b) {
            var value = b[f];
            if ($.isArray(value)) {
                for (var i in value)
                    a = d("<input />"), a.attr("type", "hidden"), a.attr("name", f), a.attr("value", value[i]), a.appendTo(e);
            }
            else {
                a = d("<input />"), a.attr("type", "hidden"), a.attr("name", f), a.attr("value", value), a.appendTo(e);
            }
        }
        d("body").append(e);
        e.submit();
        e.remove();
    };
    d.fn.parse_url = function (a) {
        if (-1 == a.indexOf("?")) return {
            url: a,
            params: {}
        };
        var b = a.split("?"),
            a = b[0],
            c = {}, b = b[1].split("&"),
            e = {}, d;
        for (d in b) {
            var g = b[d].split("=");
            e[g[0]] = g[1]
        }
        c.url = a;
        c.params = e;
        return c
    };
    d.fn.serializeObject = function () {
        var arrayData, objectData;
        arrayData = this.serializeArray();
        objectData = {};

        $.each(arrayData, function () {
            var value;

            if (this.value != null) {
                value = this.value;
            } else {
                value = '';
            }

            if (objectData[this.name] != null) {
                if (!objectData[this.name].push) {
                    objectData[this.name] = [objectData[this.name]];
                }

                objectData[this.name].push(value);
            } else {
                objectData[this.name] = value;
            }
        });

        return objectData;
    }
})(jQuery);