! function(a, b) {
    "object" == typeof module && "object" == typeof module.exports ? module.exports = a.document ? b(a, !0) : function(a) {
        if (!a.document) throw new Error("jQuery requires a window with a document");
        return b(a)
    } : b(a)
}("undefined" != typeof window ? window : this, function(a, b) {
    function c(a) {
        var b = "length" in a && a.length,
            c = _.type(a);
        return "function" === c || _.isWindow(a) ? !1 : 1 === a.nodeType && b ? !0 : "array" === c || 0 === b || "number" == typeof b && b > 0 && b - 1 in a
    }

    function d(a, b, c) {
        if (_.isFunction(b)) return _.grep(a, function(a, d) {
            return !!b.call(a, d, a) !== c
        });
        if (b.nodeType) return _.grep(a, function(a) {
            return a === b !== c
        });
        if ("string" == typeof b) {
            if (ha.test(b)) return _.filter(b, a, c);
            b = _.filter(b, a)
        }
        return _.grep(a, function(a) {
            return U.call(b, a) >= 0 !== c
        })
    }

    function e(a, b) {
        for (;
            (a = a[b]) && 1 !== a.nodeType;);
        return a
    }

    function f(a) {
        var b = oa[a] = {};
        return _.each(a.match(na) || [], function(a, c) {
            b[c] = !0
        }), b
    }

    function g() {
        Z.removeEventListener("DOMContentLoaded", g, !1), a.removeEventListener("load", g, !1), _.ready()
    }

    function h() {
        Object.defineProperty(this.cache = {}, 0, {
            get: function() {
                return {}
            }
        }), this.expando = _.expando + h.uid++
    }

    function i(a, b, c) {
        var d;
        if (void 0 === c && 1 === a.nodeType)
            if (d = "data-" + b.replace(ua, "-$1").toLowerCase(), c = a.getAttribute(d), "string" == typeof c) {
                try {
                    c = "true" === c ? !0 : "false" === c ? !1 : "null" === c ? null : +c + "" === c ? +c : ta.test(c) ? _.parseJSON(c) : c
                } catch (e) {}
                sa.set(a, b, c)
            } else c = void 0;
        return c
    }

    function j() {
        return !0
    }

    function k() {
        return !1
    }

    function l() {
        try {
            return Z.activeElement
        } catch (a) {}
    }

    function m(a, b) {
        return _.nodeName(a, "table") && _.nodeName(11 !== b.nodeType ? b : b.firstChild, "tr") ? a.getElementsByTagName("tbody")[0] || a.appendChild(a.ownerDocument.createElement("tbody")) : a
    }

    function n(a) {
        return a.type = (null !== a.getAttribute("type")) + "/" + a.type, a
    }

    function o(a) {
        var b = Ka.exec(a.type);
        return b ? a.type = b[1] : a.removeAttribute("type"), a
    }

    function p(a, b) {
        for (var c = 0, d = a.length; d > c; c++) ra.set(a[c], "globalEval", !b || ra.get(b[c], "globalEval"))
    }

    function q(a, b) {
        var c, d, e, f, g, h, i, j;
        if (1 === b.nodeType) {
            if (ra.hasData(a) && (f = ra.access(a), g = ra.set(b, f), j = f.events)) {
                delete g.handle, g.events = {};
                for (e in j)
                    for (c = 0, d = j[e].length; d > c; c++) _.event.add(b, e, j[e][c])
            }
            sa.hasData(a) && (h = sa.access(a), i = _.extend({}, h), sa.set(b, i))
        }
    }

    function r(a, b) {
        var c = a.getElementsByTagName ? a.getElementsByTagName(b || "*") : a.querySelectorAll ? a.querySelectorAll(b || "*") : [];
        return void 0 === b || b && _.nodeName(a, b) ? _.merge([a], c) : c
    }

    function s(a, b) {
        var c = b.nodeName.toLowerCase();
        "input" === c && ya.test(a.type) ? b.checked = a.checked : ("input" === c || "textarea" === c) && (b.defaultValue = a.defaultValue)
    }

    function t(b, c) {
        var d, e = _(c.createElement(b)).appendTo(c.body),
            f = a.getDefaultComputedStyle && (d = a.getDefaultComputedStyle(e[0])) ? d.display : _.css(e[0], "display");
        return e.detach(), f
    }

    function u(a) {
        var b = Z,
            c = Oa[a];
        return c || (c = t(a, b), "none" !== c && c || (Na = (Na || _("<iframe frameborder='0' width='0' height='0'/>")).appendTo(b.documentElement), b = Na[0].contentDocument, b.write(), b.close(), c = t(a, b), Na.detach()), Oa[a] = c), c
    }

    function v(a, b, c) {
        var d, e, f, g, h = a.style;
        return c = c || Ra(a), c && (g = c.getPropertyValue(b) || c[b]), c && ("" !== g || _.contains(a.ownerDocument, a) || (g = _.style(a, b)), Qa.test(g) && Pa.test(b) && (d = h.width, e = h.minWidth, f = h.maxWidth, h.minWidth = h.maxWidth = h.width = g, g = c.width, h.width = d, h.minWidth = e, h.maxWidth = f)), void 0 !== g ? g + "" : g
    }

    function w(a, b) {
        return {
            get: function() {
                return a() ? void delete this.get : (this.get = b).apply(this, arguments)
            }
        }
    }

    function x(a, b) {
        if (b in a) return b;
        for (var c = b[0].toUpperCase() + b.slice(1), d = b, e = Xa.length; e--;)
            if (b = Xa[e] + c, b in a) return b;
        return d
    }

    function y(a, b, c) {
        var d = Ta.exec(b);
        return d ? Math.max(0, d[1] - (c || 0)) + (d[2] || "px") : b
    }

    function z(a, b, c, d, e) {
        for (var f = c === (d ? "border" : "content") ? 4 : "width" === b ? 1 : 0, g = 0; 4 > f; f += 2) "margin" === c && (g += _.css(a, c + wa[f], !0, e)), d ? ("content" === c && (g -= _.css(a, "padding" + wa[f], !0, e)), "margin" !== c && (g -= _.css(a, "border" + wa[f] + "Width", !0, e))) : (g += _.css(a, "padding" + wa[f], !0, e), "padding" !== c && (g += _.css(a, "border" + wa[f] + "Width", !0, e)));
        return g
    }

    function A(a, b, c) {
        var d = !0,
            e = "width" === b ? a.offsetWidth : a.offsetHeight,
            f = Ra(a),
            g = "border-box" === _.css(a, "boxSizing", !1, f);
        if (0 >= e || null == e) {
            if (e = v(a, b, f), (0 > e || null == e) && (e = a.style[b]), Qa.test(e)) return e;
            d = g && (Y.boxSizingReliable() || e === a.style[b]), e = parseFloat(e) || 0
        }
        return e + z(a, b, c || (g ? "border" : "content"), d, f) + "px"
    }

    function B(a, b) {
        for (var c, d, e, f = [], g = 0, h = a.length; h > g; g++) d = a[g], d.style && (f[g] = ra.get(d, "olddisplay"), c = d.style.display, b ? (f[g] || "none" !== c || (d.style.display = ""), "" === d.style.display && xa(d) && (f[g] = ra.access(d, "olddisplay", u(d.nodeName)))) : (e = xa(d), "none" === c && e || ra.set(d, "olddisplay", e ? c : _.css(d, "display"))));
        for (g = 0; h > g; g++) d = a[g], d.style && (b && "none" !== d.style.display && "" !== d.style.display || (d.style.display = b ? f[g] || "" : "none"));
        return a
    }

    function C(a, b, c, d, e) {
        return new C.prototype.init(a, b, c, d, e)
    }

    function D() {
        return setTimeout(function() {
            Ya = void 0
        }), Ya = _.now()
    }

    function E(a, b) {
        var c, d = 0,
            e = {
                height: a
            };
        for (b = b ? 1 : 0; 4 > d; d += 2 - b) c = wa[d], e["margin" + c] = e["padding" + c] = a;
        return b && (e.opacity = e.width = a), e
    }

    function F(a, b, c) {
        for (var d, e = (cb[b] || []).concat(cb["*"]), f = 0, g = e.length; g > f; f++)
            if (d = e[f].call(c, b, a)) return d
    }

    function G(a, b, c) {
        var d, e, f, g, h, i, j, k, l = this,
            m = {},
            n = a.style,
            o = a.nodeType && xa(a),
            p = ra.get(a, "fxshow");
        c.queue || (h = _._queueHooks(a, "fx"), null == h.unqueued && (h.unqueued = 0, i = h.empty.fire, h.empty.fire = function() {
            h.unqueued || i()
        }), h.unqueued++, l.always(function() {
            l.always(function() {
                h.unqueued--, _.queue(a, "fx").length || h.empty.fire()
            })
        })), 1 === a.nodeType && ("height" in b || "width" in b) && (c.overflow = [n.overflow, n.overflowX, n.overflowY], j = _.css(a, "display"), k = "none" === j ? ra.get(a, "olddisplay") || u(a.nodeName) : j, "inline" === k && "none" === _.css(a, "float") && (n.display = "inline-block")), c.overflow && (n.overflow = "hidden", l.always(function() {
            n.overflow = c.overflow[0], n.overflowX = c.overflow[1], n.overflowY = c.overflow[2]
        }));
        for (d in b)
            if (e = b[d], $a.exec(e)) {
                if (delete b[d], f = f || "toggle" === e, e === (o ? "hide" : "show")) {
                    if ("show" !== e || !p || void 0 === p[d]) continue;
                    o = !0
                }
                m[d] = p && p[d] || _.style(a, d)
            } else j = void 0;
        if (_.isEmptyObject(m)) "inline" === ("none" === j ? u(a.nodeName) : j) && (n.display = j);
        else {
            p ? "hidden" in p && (o = p.hidden) : p = ra.access(a, "fxshow", {}), f && (p.hidden = !o), o ? _(a).show() : l.done(function() {
                _(a).hide()
            }), l.done(function() {
                var b;
                ra.remove(a, "fxshow");
                for (b in m) _.style(a, b, m[b])
            });
            for (d in m) g = F(o ? p[d] : 0, d, l), d in p || (p[d] = g.start, o && (g.end = g.start, g.start = "width" === d || "height" === d ? 1 : 0))
        }
    }

    function H(a, b) {
        var c, d, e, f, g;
        for (c in a)
            if (d = _.camelCase(c), e = b[d], f = a[c], _.isArray(f) && (e = f[1], f = a[c] = f[0]), c !== d && (a[d] = f, delete a[c]), g = _.cssHooks[d], g && "expand" in g) {
                f = g.expand(f), delete a[d];
                for (c in f) c in a || (a[c] = f[c], b[c] = e)
            } else b[d] = e
    }

    function I(a, b, c) {
        var d, e, f = 0,
            g = bb.length,
            h = _.Deferred().always(function() {
                delete i.elem
            }),
            i = function() {
                if (e) return !1;
                for (var b = Ya || D(), c = Math.max(0, j.startTime + j.duration - b), d = c / j.duration || 0, f = 1 - d, g = 0, i = j.tweens.length; i > g; g++) j.tweens[g].run(f);
                return h.notifyWith(a, [j, f, c]), 1 > f && i ? c : (h.resolveWith(a, [j]), !1)
            },
            j = h.promise({
                elem: a,
                props: _.extend({}, b),
                opts: _.extend(!0, {
                    specialEasing: {}
                }, c),
                originalProperties: b,
                originalOptions: c,
                startTime: Ya || D(),
                duration: c.duration,
                tweens: [],
                createTween: function(b, c) {
                    var d = _.Tween(a, j.opts, b, c, j.opts.specialEasing[b] || j.opts.easing);
                    return j.tweens.push(d), d
                },
                stop: function(b) {
                    var c = 0,
                        d = b ? j.tweens.length : 0;
                    if (e) return this;
                    for (e = !0; d > c; c++) j.tweens[c].run(1);
                    return b ? h.resolveWith(a, [j, b]) : h.rejectWith(a, [j, b]), this
                }
            }),
            k = j.props;
        for (H(k, j.opts.specialEasing); g > f; f++)
            if (d = bb[f].call(j, a, k, j.opts)) return d;
        return _.map(k, F, j), _.isFunction(j.opts.start) && j.opts.start.call(a, j), _.fx.timer(_.extend(i, {
            elem: a,
            anim: j,
            queue: j.opts.queue
        })), j.progress(j.opts.progress).done(j.opts.done, j.opts.complete).fail(j.opts.fail).always(j.opts.always)
    }

    function J(a) {
        return function(b, c) {
            "string" != typeof b && (c = b, b = "*");
            var d, e = 0,
                f = b.toLowerCase().match(na) || [];
            if (_.isFunction(c))
                for (; d = f[e++];) "+" === d[0] ? (d = d.slice(1) || "*", (a[d] = a[d] || []).unshift(c)) : (a[d] = a[d] || []).push(c)
        }
    }

    function K(a, b, c, d) {
        function e(h) {
            var i;
            return f[h] = !0, _.each(a[h] || [], function(a, h) {
                var j = h(b, c, d);
                return "string" != typeof j || g || f[j] ? g ? !(i = j) : void 0 : (b.dataTypes.unshift(j), e(j), !1)
            }), i
        }
        var f = {},
            g = a === tb;
        return e(b.dataTypes[0]) || !f["*"] && e("*")
    }

    function L(a, b) {
        var c, d, e = _.ajaxSettings.flatOptions || {};
        for (c in b) void 0 !== b[c] && ((e[c] ? a : d || (d = {}))[c] = b[c]);
        return d && _.extend(!0, a, d), a
    }

    function M(a, b, c) {
        for (var d, e, f, g, h = a.contents, i = a.dataTypes;
            "*" === i[0];) i.shift(), void 0 === d && (d = a.mimeType || b.getResponseHeader("Content-Type"));
        if (d)
            for (e in h)
                if (h[e] && h[e].test(d)) {
                    i.unshift(e);
                    break
                }
        if (i[0] in c) f = i[0];
        else {
            for (e in c) {
                if (!i[0] || a.converters[e + " " + i[0]]) {
                    f = e;
                    break
                }
                g || (g = e)
            }
            f = f || g
        }
        return f ? (f !== i[0] && i.unshift(f), c[f]) : void 0
    }

    function N(a, b, c, d) {
        var e, f, g, h, i, j = {},
            k = a.dataTypes.slice();
        if (k[1])
            for (g in a.converters) j[g.toLowerCase()] = a.converters[g];
        for (f = k.shift(); f;)
            if (a.responseFields[f] && (c[a.responseFields[f]] = b), !i && d && a.dataFilter && (b = a.dataFilter(b, a.dataType)), i = f, f = k.shift())
                if ("*" === f) f = i;
                else if ("*" !== i && i !== f) {
            if (g = j[i + " " + f] || j["* " + f], !g)
                for (e in j)
                    if (h = e.split(" "), h[1] === f && (g = j[i + " " + h[0]] || j["* " + h[0]])) {
                        g === !0 ? g = j[e] : j[e] !== !0 && (f = h[0], k.unshift(h[1]));
                        break
                    }
            if (g !== !0)
                if (g && a["throws"]) b = g(b);
                else try {
                    b = g(b)
                } catch (l) {
                    return {
                        state: "parsererror",
                        error: g ? l : "No conversion from " + i + " to " + f
                    }
                }
        }
        return {
            state: "success",
            data: b
        }
    }

    function O(a, b, c, d) {
        var e;
        if (_.isArray(b)) _.each(b, function(b, e) {
            c || yb.test(a) ? d(a, e) : O(a + "[" + ("object" == typeof e ? b : "") + "]", e, c, d)
        });
        else if (c || "object" !== _.type(b)) d(a, b);
        else
            for (e in b) O(a + "[" + e + "]", b[e], c, d)
    }

    function P(a) {
        return _.isWindow(a) ? a : 9 === a.nodeType && a.defaultView
    }
    var Q = [],
        R = Q.slice,
        S = Q.concat,
        T = Q.push,
        U = Q.indexOf,
        V = {},
        W = V.toString,
        X = V.hasOwnProperty,
        Y = {},
        Z = a.document,
        $ = "2.1.4",
        _ = function(a, b) {
            return new _.fn.init(a, b)
        },
        aa = /^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g,
        ba = /^-ms-/,
        ca = /-([\da-z])/gi,
        da = function(a, b) {
            return b.toUpperCase()
        };
    _.fn = _.prototype = {
        jquery: $,
        constructor: _,
        selector: "",
        length: 0,
        toArray: function() {
            return R.call(this)
        },
        get: function(a) {
            return null != a ? 0 > a ? this[a + this.length] : this[a] : R.call(this)
        },
        pushStack: function(a) {
            var b = _.merge(this.constructor(), a);
            return b.prevObject = this, b.context = this.context, b
        },
        each: function(a, b) {
            return _.each(this, a, b)
        },
        map: function(a) {
            return this.pushStack(_.map(this, function(b, c) {
                return a.call(b, c, b)
            }))
        },
        slice: function() {
            return this.pushStack(R.apply(this, arguments))
        },
        first: function() {
            return this.eq(0)
        },
        last: function() {
            return this.eq(-1)
        },
        eq: function(a) {
            var b = this.length,
                c = +a + (0 > a ? b : 0);
            return this.pushStack(c >= 0 && b > c ? [this[c]] : [])
        },
        end: function() {
            return this.prevObject || this.constructor(null)
        },
        push: T,
        sort: Q.sort,
        splice: Q.splice
    }, _.extend = _.fn.extend = function() {
        var a, b, c, d, e, f, g = arguments[0] || {},
            h = 1,
            i = arguments.length,
            j = !1;
        for ("boolean" == typeof g && (j = g, g = arguments[h] || {}, h++), "object" == typeof g || _.isFunction(g) || (g = {}), h === i && (g = this, h--); i > h; h++)
            if (null != (a = arguments[h]))
                for (b in a) c = g[b], d = a[b], g !== d && (j && d && (_.isPlainObject(d) || (e = _.isArray(d))) ? (e ? (e = !1, f = c && _.isArray(c) ? c : []) : f = c && _.isPlainObject(c) ? c : {}, g[b] = _.extend(j, f, d)) : void 0 !== d && (g[b] = d));
        return g
    }, _.extend({
        expando: "jQuery" + ($ + Math.random()).replace(/\D/g, ""),
        isReady: !0,
        error: function(a) {
            throw new Error(a)
        },
        noop: function() {},
        isFunction: function(a) {
            return "function" === _.type(a)
        },
        isArray: Array.isArray,
        isWindow: function(a) {
            return null != a && a === a.window
        },
        isNumeric: function(a) {
            return !_.isArray(a) && a - parseFloat(a) + 1 >= 0
        },
        isPlainObject: function(a) {
            return "object" !== _.type(a) || a.nodeType || _.isWindow(a) ? !1 : a.constructor && !X.call(a.constructor.prototype, "isPrototypeOf") ? !1 : !0
        },
        isEmptyObject: function(a) {
            var b;
            for (b in a) return !1;
            return !0
        },
        type: function(a) {
            return null == a ? a + "" : "object" == typeof a || "function" == typeof a ? V[W.call(a)] || "object" : typeof a
        },
        globalEval: function(a) {
            var b, c = eval;
            a = _.trim(a), a && (1 === a.indexOf("use strict") ? (b = Z.createElement("script"), b.text = a, Z.head.appendChild(b).parentNode.removeChild(b)) : c(a))
        },
        camelCase: function(a) {
            return a.replace(ba, "ms-").replace(ca, da)
        },
        nodeName: function(a, b) {
            return a.nodeName && a.nodeName.toLowerCase() === b.toLowerCase()
        },
        each: function(a, b, d) {
            var e, f = 0,
                g = a.length,
                h = c(a);
            if (d) {
                if (h)
                    for (; g > f && (e = b.apply(a[f], d), e !== !1); f++);
                else
                    for (f in a)
                        if (e = b.apply(a[f], d), e === !1) break
            } else if (h)
                for (; g > f && (e = b.call(a[f], f, a[f]), e !== !1); f++);
            else
                for (f in a)
                    if (e = b.call(a[f], f, a[f]), e === !1) break; return a
        },
        trim: function(a) {
            return null == a ? "" : (a + "").replace(aa, "")
        },
        makeArray: function(a, b) {
            var d = b || [];
            return null != a && (c(Object(a)) ? _.merge(d, "string" == typeof a ? [a] : a) : T.call(d, a)), d
        },
        inArray: function(a, b, c) {
            return null == b ? -1 : U.call(b, a, c)
        },
        merge: function(a, b) {
            for (var c = +b.length, d = 0, e = a.length; c > d; d++) a[e++] = b[d];
            return a.length = e, a
        },
        grep: function(a, b, c) {
            for (var d, e = [], f = 0, g = a.length, h = !c; g > f; f++) d = !b(a[f], f), d !== h && e.push(a[f]);
            return e
        },
        map: function(a, b, d) {
            var e, f = 0,
                g = a.length,
                h = c(a),
                i = [];
            if (h)
                for (; g > f; f++) e = b(a[f], f, d), null != e && i.push(e);
            else
                for (f in a) e = b(a[f], f, d), null != e && i.push(e);
            return S.apply([], i)
        },
        guid: 1,
        proxy: function(a, b) {
            var c, d, e;
            return "string" == typeof b && (c = a[b], b = a, a = c), _.isFunction(a) ? (d = R.call(arguments, 2), e = function() {
                return a.apply(b || this, d.concat(R.call(arguments)))
            }, e.guid = a.guid = a.guid || _.guid++, e) : void 0
        },
        now: Date.now,
        support: Y
    }), _.each("Boolean Number String Function Array Date RegExp Object Error".split(" "), function(a, b) {
        V["[object " + b + "]"] = b.toLowerCase()
    });
    var ea = function(a) {
        function b(a, b, c, d) {
            var e, f, g, h, i, j, l, n, o, p;
            if ((b ? b.ownerDocument || b : O) !== G && F(b), b = b || G, c = c || [], h = b.nodeType, "string" != typeof a || !a || 1 !== h && 9 !== h && 11 !== h) return c;
            if (!d && I) {
                if (11 !== h && (e = sa.exec(a)))
                    if (g = e[1]) {
                        if (9 === h) {
                            if (f = b.getElementById(g), !f || !f.parentNode) return c;
                            if (f.id === g) return c.push(f), c
                        } else if (b.ownerDocument && (f = b.ownerDocument.getElementById(g)) && M(b, f) && f.id === g) return c.push(f), c
                    } else {
                        if (e[2]) return $.apply(c, b.getElementsByTagName(a)), c;
                        if ((g = e[3]) && v.getElementsByClassName) return $.apply(c, b.getElementsByClassName(g)), c
                    }
                if (v.qsa && (!J || !J.test(a))) {
                    if (n = l = N, o = b, p = 1 !== h && a, 1 === h && "object" !== b.nodeName.toLowerCase()) {
                        for (j = z(a), (l = b.getAttribute("id")) ? n = l.replace(ua, "\\$&") : b.setAttribute("id", n), n = "[id='" + n + "'] ", i = j.length; i--;) j[i] = n + m(j[i]);
                        o = ta.test(a) && k(b.parentNode) || b, p = j.join(",")
                    }
                    if (p) try {
                        return $.apply(c, o.querySelectorAll(p)), c
                    } catch (q) {} finally {
                        l || b.removeAttribute("id")
                    }
                }
            }
            return B(a.replace(ia, "$1"), b, c, d)
        }

        function c() {
            function a(c, d) {
                return b.push(c + " ") > w.cacheLength && delete a[b.shift()], a[c + " "] = d
            }
            var b = [];
            return a
        }

        function d(a) {
            return a[N] = !0, a
        }

        function e(a) {
            var b = G.createElement("div");
            try {
                return !!a(b)
            } catch (c) {
                return !1
            } finally {
                b.parentNode && b.parentNode.removeChild(b), b = null
            }
        }

        function f(a, b) {
            for (var c = a.split("|"), d = a.length; d--;) w.attrHandle[c[d]] = b
        }

        function g(a, b) {
            var c = b && a,
                d = c && 1 === a.nodeType && 1 === b.nodeType && (~b.sourceIndex || V) - (~a.sourceIndex || V);
            if (d) return d;
            if (c)
                for (; c = c.nextSibling;)
                    if (c === b) return -1;
            return a ? 1 : -1
        }

        function h(a) {
            return function(b) {
                var c = b.nodeName.toLowerCase();
                return "input" === c && b.type === a
            }
        }

        function i(a) {
            return function(b) {
                var c = b.nodeName.toLowerCase();
                return ("input" === c || "button" === c) && b.type === a
            }
        }

        function j(a) {
            return d(function(b) {
                return b = +b, d(function(c, d) {
                    for (var e, f = a([], c.length, b), g = f.length; g--;) c[e = f[g]] && (c[e] = !(d[e] = c[e]))
                })
            })
        }

        function k(a) {
            return a && "undefined" != typeof a.getElementsByTagName && a
        }

        function l() {}

        function m(a) {
            for (var b = 0, c = a.length, d = ""; c > b; b++) d += a[b].value;
            return d
        }

        function n(a, b, c) {
            var d = b.dir,
                e = c && "parentNode" === d,
                f = Q++;
            return b.first ? function(b, c, f) {
                for (; b = b[d];)
                    if (1 === b.nodeType || e) return a(b, c, f)
            } : function(b, c, g) {
                var h, i, j = [P, f];
                if (g) {
                    for (; b = b[d];)
                        if ((1 === b.nodeType || e) && a(b, c, g)) return !0
                } else
                    for (; b = b[d];)
                        if (1 === b.nodeType || e) {
                            if (i = b[N] || (b[N] = {}), (h = i[d]) && h[0] === P && h[1] === f) return j[2] = h[2];
                            if (i[d] = j, j[2] = a(b, c, g)) return !0
                        }
            }
        }

        function o(a) {
            return a.length > 1 ? function(b, c, d) {
                for (var e = a.length; e--;)
                    if (!a[e](b, c, d)) return !1;
                return !0
            } : a[0]
        }

        function p(a, c, d) {
            for (var e = 0, f = c.length; f > e; e++) b(a, c[e], d);
            return d
        }

        function q(a, b, c, d, e) {
            for (var f, g = [], h = 0, i = a.length, j = null != b; i > h; h++)(f = a[h]) && (!c || c(f, d, e)) && (g.push(f), j && b.push(h));
            return g
        }

        function r(a, b, c, e, f, g) {
            return e && !e[N] && (e = r(e)), f && !f[N] && (f = r(f, g)), d(function(d, g, h, i) {
                var j, k, l, m = [],
                    n = [],
                    o = g.length,
                    r = d || p(b || "*", h.nodeType ? [h] : h, []),
                    s = !a || !d && b ? r : q(r, m, a, h, i),
                    t = c ? f || (d ? a : o || e) ? [] : g : s;
                if (c && c(s, t, h, i), e)
                    for (j = q(t, n), e(j, [], h, i), k = j.length; k--;)(l = j[k]) && (t[n[k]] = !(s[n[k]] = l));
                if (d) {
                    if (f || a) {
                        if (f) {
                            for (j = [], k = t.length; k--;)(l = t[k]) && j.push(s[k] = l);
                            f(null, t = [], j, i)
                        }
                        for (k = t.length; k--;)(l = t[k]) && (j = f ? aa(d, l) : m[k]) > -1 && (d[j] = !(g[j] = l))
                    }
                } else t = q(t === g ? t.splice(o, t.length) : t), f ? f(null, g, t, i) : $.apply(g, t)
            })
        }

        function s(a) {
            for (var b, c, d, e = a.length, f = w.relative[a[0].type], g = f || w.relative[" "], h = f ? 1 : 0, i = n(function(a) {
                    return a === b
                }, g, !0), j = n(function(a) {
                    return aa(b, a) > -1
                }, g, !0), k = [function(a, c, d) {
                    var e = !f && (d || c !== C) || ((b = c).nodeType ? i(a, c, d) : j(a, c, d));
                    return b = null, e
                }]; e > h; h++)
                if (c = w.relative[a[h].type]) k = [n(o(k), c)];
                else {
                    if (c = w.filter[a[h].type].apply(null, a[h].matches), c[N]) {
                        for (d = ++h; e > d && !w.relative[a[d].type]; d++);
                        return r(h > 1 && o(k), h > 1 && m(a.slice(0, h - 1).concat({
                            value: " " === a[h - 2].type ? "*" : ""
                        })).replace(ia, "$1"), c, d > h && s(a.slice(h, d)), e > d && s(a = a.slice(d)), e > d && m(a))
                    }
                    k.push(c)
                }
            return o(k)
        }

        function t(a, c) {
            var e = c.length > 0,
                f = a.length > 0,
                g = function(d, g, h, i, j) {
                    var k, l, m, n = 0,
                        o = "0",
                        p = d && [],
                        r = [],
                        s = C,
                        t = d || f && w.find.TAG("*", j),
                        u = P += null == s ? 1 : Math.random() || .1,
                        v = t.length;
                    for (j && (C = g !== G && g); o !== v && null != (k = t[o]); o++) {
                        if (f && k) {
                            for (l = 0; m = a[l++];)
                                if (m(k, g, h)) {
                                    i.push(k);
                                    break
                                }
                            j && (P = u)
                        }
                        e && ((k = !m && k) && n--, d && p.push(k))
                    }
                    if (n += o, e && o !== n) {
                        for (l = 0; m = c[l++];) m(p, r, g, h);
                        if (d) {
                            if (n > 0)
                                for (; o--;) p[o] || r[o] || (r[o] = Y.call(i));
                            r = q(r)
                        }
                        $.apply(i, r), j && !d && r.length > 0 && n + c.length > 1 && b.uniqueSort(i)
                    }
                    return j && (P = u, C = s), p
                };
            return e ? d(g) : g
        }
        var u, v, w, x, y, z, A, B, C, D, E, F, G, H, I, J, K, L, M, N = "sizzle" + 1 * new Date,
            O = a.document,
            P = 0,
            Q = 0,
            R = c(),
            S = c(),
            T = c(),
            U = function(a, b) {
                return a === b && (E = !0), 0
            },
            V = 1 << 31,
            W = {}.hasOwnProperty,
            X = [],
            Y = X.pop,
            Z = X.push,
            $ = X.push,
            _ = X.slice,
            aa = function(a, b) {
                for (var c = 0, d = a.length; d > c; c++)
                    if (a[c] === b) return c;
                return -1
            },
            ba = "checked|selected|async|autofocus|autoplay|controls|defer|disabled|hidden|ismap|loop|multiple|open|readonly|required|scoped",
            ca = "[\\x20\\t\\r\\n\\f]",
            da = "(?:\\\\.|[\\w-]|[^\\x00-\\xa0])+",
            ea = da.replace("w", "w#"),
            fa = "\\[" + ca + "*(" + da + ")(?:" + ca + "*([*^$|!~]?=)" + ca + "*(?:'((?:\\\\.|[^\\\\'])*)'|\"((?:\\\\.|[^\\\\\"])*)\"|(" + ea + "))|)" + ca + "*\\]",
            ga = ":(" + da + ")(?:\\((('((?:\\\\.|[^\\\\'])*)'|\"((?:\\\\.|[^\\\\\"])*)\")|((?:\\\\.|[^\\\\()[\\]]|" + fa + ")*)|.*)\\)|)",
            ha = new RegExp(ca + "+", "g"),
            ia = new RegExp("^" + ca + "+|((?:^|[^\\\\])(?:\\\\.)*)" + ca + "+$", "g"),
            ja = new RegExp("^" + ca + "*," + ca + "*"),
            ka = new RegExp("^" + ca + "*([>+~]|" + ca + ")" + ca + "*"),
            la = new RegExp("=" + ca + "*([^\\]'\"]*?)" + ca + "*\\]", "g"),
            ma = new RegExp(ga),
            na = new RegExp("^" + ea + "$"),
            oa = {
                ID: new RegExp("^#(" + da + ")"),
                CLASS: new RegExp("^\\.(" + da + ")"),
                TAG: new RegExp("^(" + da.replace("w", "w*") + ")"),
                ATTR: new RegExp("^" + fa),
                PSEUDO: new RegExp("^" + ga),
                CHILD: new RegExp("^:(only|first|last|nth|nth-last)-(child|of-type)(?:\\(" + ca + "*(even|odd|(([+-]|)(\\d*)n|)" + ca + "*(?:([+-]|)" + ca + "*(\\d+)|))" + ca + "*\\)|)", "i"),
                bool: new RegExp("^(?:" + ba + ")$", "i"),
                needsContext: new RegExp("^" + ca + "*[>+~]|:(even|odd|eq|gt|lt|nth|first|last)(?:\\(" + ca + "*((?:-\\d)?\\d*)" + ca + "*\\)|)(?=[^-]|$)", "i")
            },
            pa = /^(?:input|select|textarea|button)$/i,
            qa = /^h\d$/i,
            ra = /^[^{]+\{\s*\[native \w/,
            sa = /^(?:#([\w-]+)|(\w+)|\.([\w-]+))$/,
            ta = /[+~]/,
            ua = /'|\\/g,
            va = new RegExp("\\\\([\\da-f]{1,6}" + ca + "?|(" + ca + ")|.)", "ig"),
            wa = function(a, b, c) {
                var d = "0x" + b - 65536;
                return d !== d || c ? b : 0 > d ? String.fromCharCode(d + 65536) : String.fromCharCode(d >> 10 | 55296, 1023 & d | 56320)
            },
            xa = function() {
                F()
            };
        try {
            $.apply(X = _.call(O.childNodes), O.childNodes), X[O.childNodes.length].nodeType
        } catch (ya) {
            $ = {
                apply: X.length ? function(a, b) {
                    Z.apply(a, _.call(b))
                } : function(a, b) {
                    for (var c = a.length, d = 0; a[c++] = b[d++];);
                    a.length = c - 1
                }
            }
        }
        v = b.support = {}, y = b.isXML = function(a) {
            var b = a && (a.ownerDocument || a).documentElement;
            return b ? "HTML" !== b.nodeName : !1
        }, F = b.setDocument = function(a) {
            var b, c, d = a ? a.ownerDocument || a : O;
            return d !== G && 9 === d.nodeType && d.documentElement ? (G = d, H = d.documentElement, c = d.defaultView, c && c !== c.top && (c.addEventListener ? c.addEventListener("unload", xa, !1) : c.attachEvent && c.attachEvent("onunload", xa)), I = !y(d), v.attributes = e(function(a) {
                return a.className = "i", !a.getAttribute("className")
            }), v.getElementsByTagName = e(function(a) {
                return a.appendChild(d.createComment("")), !a.getElementsByTagName("*").length
            }), v.getElementsByClassName = ra.test(d.getElementsByClassName), v.getById = e(function(a) {
                return H.appendChild(a).id = N, !d.getElementsByName || !d.getElementsByName(N).length
            }), v.getById ? (w.find.ID = function(a, b) {
                if ("undefined" != typeof b.getElementById && I) {
                    var c = b.getElementById(a);
                    return c && c.parentNode ? [c] : []
                }
            }, w.filter.ID = function(a) {
                var b = a.replace(va, wa);
                return function(a) {
                    return a.getAttribute("id") === b
                }
            }) : (delete w.find.ID, w.filter.ID = function(a) {
                var b = a.replace(va, wa);
                return function(a) {
                    var c = "undefined" != typeof a.getAttributeNode && a.getAttributeNode("id");
                    return c && c.value === b
                }
            }), w.find.TAG = v.getElementsByTagName ? function(a, b) {
                return "undefined" != typeof b.getElementsByTagName ? b.getElementsByTagName(a) : v.qsa ? b.querySelectorAll(a) : void 0
            } : function(a, b) {
                var c, d = [],
                    e = 0,
                    f = b.getElementsByTagName(a);
                if ("*" === a) {
                    for (; c = f[e++];) 1 === c.nodeType && d.push(c);
                    return d
                }
                return f
            }, w.find.CLASS = v.getElementsByClassName && function(a, b) {
                return I ? b.getElementsByClassName(a) : void 0
            }, K = [], J = [], (v.qsa = ra.test(d.querySelectorAll)) && (e(function(a) {
                H.appendChild(a).innerHTML = "<a id='" + N + "'></a><select id='" + N + "-\f]' msallowcapture=''><option selected=''></option></select>", a.querySelectorAll("[msallowcapture^='']").length && J.push("[*^$]=" + ca + "*(?:''|\"\")"), a.querySelectorAll("[selected]").length || J.push("\\[" + ca + "*(?:value|" + ba + ")"), a.querySelectorAll("[id~=" + N + "-]").length || J.push("~="), a.querySelectorAll(":checked").length || J.push(":checked"), a.querySelectorAll("a#" + N + "+*").length || J.push(".#.+[+~]")
            }), e(function(a) {
                var b = d.createElement("input");
                b.setAttribute("type", "hidden"), a.appendChild(b).setAttribute("name", "D"), a.querySelectorAll("[name=d]").length && J.push("name" + ca + "*[*^$|!~]?="), a.querySelectorAll(":enabled").length || J.push(":enabled", ":disabled"), a.querySelectorAll("*,:x"), J.push(",.*:")
            })), (v.matchesSelector = ra.test(L = H.matches || H.webkitMatchesSelector || H.mozMatchesSelector || H.oMatchesSelector || H.msMatchesSelector)) && e(function(a) {
                v.disconnectedMatch = L.call(a, "div"), L.call(a, "[s!='']:x"), K.push("!=", ga)
            }), J = J.length && new RegExp(J.join("|")), K = K.length && new RegExp(K.join("|")), b = ra.test(H.compareDocumentPosition), M = b || ra.test(H.contains) ? function(a, b) {
                var c = 9 === a.nodeType ? a.documentElement : a,
                    d = b && b.parentNode;
                return a === d || !(!d || 1 !== d.nodeType || !(c.contains ? c.contains(d) : a.compareDocumentPosition && 16 & a.compareDocumentPosition(d)))
            } : function(a, b) {
                if (b)
                    for (; b = b.parentNode;)
                        if (b === a) return !0;
                return !1
            }, U = b ? function(a, b) {
                if (a === b) return E = !0, 0;
                var c = !a.compareDocumentPosition - !b.compareDocumentPosition;
                return c ? c : (c = (a.ownerDocument || a) === (b.ownerDocument || b) ? a.compareDocumentPosition(b) : 1, 1 & c || !v.sortDetached && b.compareDocumentPosition(a) === c ? a === d || a.ownerDocument === O && M(O, a) ? -1 : b === d || b.ownerDocument === O && M(O, b) ? 1 : D ? aa(D, a) - aa(D, b) : 0 : 4 & c ? -1 : 1)
            } : function(a, b) {
                if (a === b) return E = !0, 0;
                var c, e = 0,
                    f = a.parentNode,
                    h = b.parentNode,
                    i = [a],
                    j = [b];
                if (!f || !h) return a === d ? -1 : b === d ? 1 : f ? -1 : h ? 1 : D ? aa(D, a) - aa(D, b) : 0;
                if (f === h) return g(a, b);
                for (c = a; c = c.parentNode;) i.unshift(c);
                for (c = b; c = c.parentNode;) j.unshift(c);
                for (; i[e] === j[e];) e++;
                return e ? g(i[e], j[e]) : i[e] === O ? -1 : j[e] === O ? 1 : 0
            }, d) : G
        }, b.matches = function(a, c) {
            return b(a, null, null, c)
        }, b.matchesSelector = function(a, c) {
            if ((a.ownerDocument || a) !== G && F(a), c = c.replace(la, "='$1']"), !(!v.matchesSelector || !I || K && K.test(c) || J && J.test(c))) try {
                var d = L.call(a, c);
                if (d || v.disconnectedMatch || a.document && 11 !== a.document.nodeType) return d
            } catch (e) {}
            return b(c, G, null, [a]).length > 0
        }, b.contains = function(a, b) {
            return (a.ownerDocument || a) !== G && F(a), M(a, b)
        }, b.attr = function(a, b) {
            (a.ownerDocument || a) !== G && F(a);
            var c = w.attrHandle[b.toLowerCase()],
                d = c && W.call(w.attrHandle, b.toLowerCase()) ? c(a, b, !I) : void 0;
            return void 0 !== d ? d : v.attributes || !I ? a.getAttribute(b) : (d = a.getAttributeNode(b)) && d.specified ? d.value : null
        }, b.error = function(a) {
            throw new Error("Syntax error, unrecognized expression: " + a)
        }, b.uniqueSort = function(a) {
            var b, c = [],
                d = 0,
                e = 0;
            if (E = !v.detectDuplicates, D = !v.sortStable && a.slice(0), a.sort(U), E) {
                for (; b = a[e++];) b === a[e] && (d = c.push(e));
                for (; d--;) a.splice(c[d], 1)
            }
            return D = null, a
        }, x = b.getText = function(a) {
            var b, c = "",
                d = 0,
                e = a.nodeType;
            if (e) {
                if (1 === e || 9 === e || 11 === e) {
                    if ("string" == typeof a.textContent) return a.textContent;
                    for (a = a.firstChild; a; a = a.nextSibling) c += x(a)
                } else if (3 === e || 4 === e) return a.nodeValue
            } else
                for (; b = a[d++];) c += x(b);
            return c
        }, w = b.selectors = {
            cacheLength: 50,
            createPseudo: d,
            match: oa,
            attrHandle: {},
            find: {},
            relative: {
                ">": {
                    dir: "parentNode",
                    first: !0
                },
                " ": {
                    dir: "parentNode"
                },
                "+": {
                    dir: "previousSibling",
                    first: !0
                },
                "~": {
                    dir: "previousSibling"
                }
            },
            preFilter: {
                ATTR: function(a) {
                    return a[1] = a[1].replace(va, wa), a[3] = (a[3] || a[4] || a[5] || "").replace(va, wa), "~=" === a[2] && (a[3] = " " + a[3] + " "), a.slice(0, 4)
                },
                CHILD: function(a) {
                    return a[1] = a[1].toLowerCase(), "nth" === a[1].slice(0, 3) ? (a[3] || b.error(a[0]), a[4] = +(a[4] ? a[5] + (a[6] || 1) : 2 * ("even" === a[3] || "odd" === a[3])), a[5] = +(a[7] + a[8] || "odd" === a[3])) : a[3] && b.error(a[0]), a
                },
                PSEUDO: function(a) {
                    var b, c = !a[6] && a[2];
                    return oa.CHILD.test(a[0]) ? null : (a[3] ? a[2] = a[4] || a[5] || "" : c && ma.test(c) && (b = z(c, !0)) && (b = c.indexOf(")", c.length - b) - c.length) && (a[0] = a[0].slice(0, b), a[2] = c.slice(0, b)), a.slice(0, 3))
                }
            },
            filter: {
                TAG: function(a) {
                    var b = a.replace(va, wa).toLowerCase();
                    return "*" === a ? function() {
                        return !0
                    } : function(a) {
                        return a.nodeName && a.nodeName.toLowerCase() === b
                    }
                },
                CLASS: function(a) {
                    var b = R[a + " "];
                    return b || (b = new RegExp("(^|" + ca + ")" + a + "(" + ca + "|$)")) && R(a, function(a) {
                        return b.test("string" == typeof a.className && a.className || "undefined" != typeof a.getAttribute && a.getAttribute("class") || "")
                    })
                },
                ATTR: function(a, c, d) {
                    return function(e) {
                        var f = b.attr(e, a);
                        return null == f ? "!=" === c : c ? (f += "", "=" === c ? f === d : "!=" === c ? f !== d : "^=" === c ? d && 0 === f.indexOf(d) : "*=" === c ? d && f.indexOf(d) > -1 : "$=" === c ? d && f.slice(-d.length) === d : "~=" === c ? (" " + f.replace(ha, " ") + " ").indexOf(d) > -1 : "|=" === c ? f === d || f.slice(0, d.length + 1) === d + "-" : !1) : !0
                    }
                },
                CHILD: function(a, b, c, d, e) {
                    var f = "nth" !== a.slice(0, 3),
                        g = "last" !== a.slice(-4),
                        h = "of-type" === b;
                    return 1 === d && 0 === e ? function(a) {
                        return !!a.parentNode
                    } : function(b, c, i) {
                        var j, k, l, m, n, o, p = f !== g ? "nextSibling" : "previousSibling",
                            q = b.parentNode,
                            r = h && b.nodeName.toLowerCase(),
                            s = !i && !h;
                        if (q) {
                            if (f) {
                                for (; p;) {
                                    for (l = b; l = l[p];)
                                        if (h ? l.nodeName.toLowerCase() === r : 1 === l.nodeType) return !1;
                                    o = p = "only" === a && !o && "nextSibling"
                                }
                                return !0
                            }
                            if (o = [g ? q.firstChild : q.lastChild], g && s) {
                                for (k = q[N] || (q[N] = {}), j = k[a] || [], n = j[0] === P && j[1], m = j[0] === P && j[2], l = n && q.childNodes[n]; l = ++n && l && l[p] || (m = n = 0) || o.pop();)
                                    if (1 === l.nodeType && ++m && l === b) {
                                        k[a] = [P, n, m];
                                        break
                                    }
                            } else if (s && (j = (b[N] || (b[N] = {}))[a]) && j[0] === P) m = j[1];
                            else
                                for (;
                                    (l = ++n && l && l[p] || (m = n = 0) || o.pop()) && ((h ? l.nodeName.toLowerCase() !== r : 1 !== l.nodeType) || !++m || (s && ((l[N] || (l[N] = {}))[a] = [P, m]), l !== b)););
                            return m -= e, m === d || m % d === 0 && m / d >= 0
                        }
                    }
                },
                PSEUDO: function(a, c) {
                    var e, f = w.pseudos[a] || w.setFilters[a.toLowerCase()] || b.error("unsupported pseudo: " + a);
                    return f[N] ? f(c) : f.length > 1 ? (e = [a, a, "", c], w.setFilters.hasOwnProperty(a.toLowerCase()) ? d(function(a, b) {
                        for (var d, e = f(a, c), g = e.length; g--;) d = aa(a, e[g]), a[d] = !(b[d] = e[g])
                    }) : function(a) {
                        return f(a, 0, e)
                    }) : f
                }
            },
            pseudos: {
                not: d(function(a) {
                    var b = [],
                        c = [],
                        e = A(a.replace(ia, "$1"));
                    return e[N] ? d(function(a, b, c, d) {
                        for (var f, g = e(a, null, d, []), h = a.length; h--;)(f = g[h]) && (a[h] = !(b[h] = f))
                    }) : function(a, d, f) {
                        return b[0] = a, e(b, null, f, c), b[0] = null, !c.pop()
                    }
                }),
                has: d(function(a) {
                    return function(c) {
                        return b(a, c).length > 0
                    }
                }),
                contains: d(function(a) {
                    return a = a.replace(va, wa),
                        function(b) {
                            return (b.textContent || b.innerText || x(b)).indexOf(a) > -1
                        }
                }),
                lang: d(function(a) {
                    return na.test(a || "") || b.error("unsupported lang: " + a), a = a.replace(va, wa).toLowerCase(),
                        function(b) {
                            var c;
                            do
                                if (c = I ? b.lang : b.getAttribute("xml:lang") || b.getAttribute("lang")) return c = c.toLowerCase(), c === a || 0 === c.indexOf(a + "-");
                            while ((b = b.parentNode) && 1 === b.nodeType);
                            return !1
                        }
                }),
                target: function(b) {
                    var c = a.location && a.location.hash;
                    return c && c.slice(1) === b.id
                },
                root: function(a) {
                    return a === H
                },
                focus: function(a) {
                    return a === G.activeElement && (!G.hasFocus || G.hasFocus()) && !!(a.type || a.href || ~a.tabIndex)
                },
                enabled: function(a) {
                    return a.disabled === !1
                },
                disabled: function(a) {
                    return a.disabled === !0
                },
                checked: function(a) {
                    var b = a.nodeName.toLowerCase();
                    return "input" === b && !!a.checked || "option" === b && !!a.selected
                },
                selected: function(a) {
                    return a.parentNode && a.parentNode.selectedIndex, a.selected === !0
                },
                empty: function(a) {
                    for (a = a.firstChild; a; a = a.nextSibling)
                        if (a.nodeType < 6) return !1;
                    return !0
                },
                parent: function(a) {
                    return !w.pseudos.empty(a)
                },
                header: function(a) {
                    return qa.test(a.nodeName)
                },
                input: function(a) {
                    return pa.test(a.nodeName)
                },
                button: function(a) {
                    var b = a.nodeName.toLowerCase();
                    return "input" === b && "button" === a.type || "button" === b
                },
                text: function(a) {
                    var b;
                    return "input" === a.nodeName.toLowerCase() && "text" === a.type && (null == (b = a.getAttribute("type")) || "text" === b.toLowerCase())
                },
                first: j(function() {
                    return [0]
                }),
                last: j(function(a, b) {
                    return [b - 1]
                }),
                eq: j(function(a, b, c) {
                    return [0 > c ? c + b : c]
                }),
                even: j(function(a, b) {
                    for (var c = 0; b > c; c += 2) a.push(c);
                    return a
                }),
                odd: j(function(a, b) {
                    for (var c = 1; b > c; c += 2) a.push(c);
                    return a
                }),
                lt: j(function(a, b, c) {
                    for (var d = 0 > c ? c + b : c; --d >= 0;) a.push(d);
                    return a
                }),
                gt: j(function(a, b, c) {
                    for (var d = 0 > c ? c + b : c; ++d < b;) a.push(d);
                    return a
                })
            }
        }, w.pseudos.nth = w.pseudos.eq;
        for (u in {
                radio: !0,
                checkbox: !0,
                file: !0,
                password: !0,
                image: !0
            }) w.pseudos[u] = h(u);
        for (u in {
                submit: !0,
                reset: !0
            }) w.pseudos[u] = i(u);
        return l.prototype = w.filters = w.pseudos, w.setFilters = new l, z = b.tokenize = function(a, c) {
            var d, e, f, g, h, i, j, k = S[a + " "];
            if (k) return c ? 0 : k.slice(0);
            for (h = a, i = [], j = w.preFilter; h;) {
                (!d || (e = ja.exec(h))) && (e && (h = h.slice(e[0].length) || h), i.push(f = [])), d = !1, (e = ka.exec(h)) && (d = e.shift(), f.push({
                    value: d,
                    type: e[0].replace(ia, " ")
                }), h = h.slice(d.length));
                for (g in w.filter) !(e = oa[g].exec(h)) || j[g] && !(e = j[g](e)) || (d = e.shift(), f.push({
                    value: d,
                    type: g,
                    matches: e
                }), h = h.slice(d.length));
                if (!d) break
            }
            return c ? h.length : h ? b.error(a) : S(a, i).slice(0)
        }, A = b.compile = function(a, b) {
            var c, d = [],
                e = [],
                f = T[a + " "];
            if (!f) {
                for (b || (b = z(a)), c = b.length; c--;) f = s(b[c]), f[N] ? d.push(f) : e.push(f);
                f = T(a, t(e, d)), f.selector = a
            }
            return f
        }, B = b.select = function(a, b, c, d) {
            var e, f, g, h, i, j = "function" == typeof a && a,
                l = !d && z(a = j.selector || a);
            if (c = c || [], 1 === l.length) {
                if (f = l[0] = l[0].slice(0), f.length > 2 && "ID" === (g = f[0]).type && v.getById && 9 === b.nodeType && I && w.relative[f[1].type]) {
                    if (b = (w.find.ID(g.matches[0].replace(va, wa), b) || [])[0], !b) return c;
                    j && (b = b.parentNode), a = a.slice(f.shift().value.length)
                }
                for (e = oa.needsContext.test(a) ? 0 : f.length; e-- && (g = f[e], !w.relative[h = g.type]);)
                    if ((i = w.find[h]) && (d = i(g.matches[0].replace(va, wa), ta.test(f[0].type) && k(b.parentNode) || b))) {
                        if (f.splice(e, 1), a = d.length && m(f), !a) return $.apply(c, d), c;
                        break
                    }
            }
            return (j || A(a, l))(d, b, !I, c, ta.test(a) && k(b.parentNode) || b), c
        }, v.sortStable = N.split("").sort(U).join("") === N, v.detectDuplicates = !!E, F(), v.sortDetached = e(function(a) {
            return 1 & a.compareDocumentPosition(G.createElement("div"))
        }), e(function(a) {
            return a.innerHTML = "<a href='#'></a>", "#" === a.firstChild.getAttribute("href")
        }) || f("type|href|height|width", function(a, b, c) {
            return c ? void 0 : a.getAttribute(b, "type" === b.toLowerCase() ? 1 : 2)
        }), v.attributes && e(function(a) {
            return a.innerHTML = "<input/>", a.firstChild.setAttribute("value", ""), "" === a.firstChild.getAttribute("value")
        }) || f("value", function(a, b, c) {
            return c || "input" !== a.nodeName.toLowerCase() ? void 0 : a.defaultValue
        }), e(function(a) {
            return null == a.getAttribute("disabled")
        }) || f(ba, function(a, b, c) {
            var d;
            return c ? void 0 : a[b] === !0 ? b.toLowerCase() : (d = a.getAttributeNode(b)) && d.specified ? d.value : null
        }), b
    }(a);
    _.find = ea, _.expr = ea.selectors, _.expr[":"] = _.expr.pseudos, _.unique = ea.uniqueSort, _.text = ea.getText, _.isXMLDoc = ea.isXML, _.contains = ea.contains;
    var fa = _.expr.match.needsContext,
        ga = /^<(\w+)\s*\/?>(?:<\/\1>|)$/,
        ha = /^.[^:#\[\.,]*$/;
    _.filter = function(a, b, c) {
        var d = b[0];
        return c && (a = ":not(" + a + ")"), 1 === b.length && 1 === d.nodeType ? _.find.matchesSelector(d, a) ? [d] : [] : _.find.matches(a, _.grep(b, function(a) {
            return 1 === a.nodeType
        }))
    }, _.fn.extend({
        find: function(a) {
            var b, c = this.length,
                d = [],
                e = this;
            if ("string" != typeof a) return this.pushStack(_(a).filter(function() {
                for (b = 0; c > b; b++)
                    if (_.contains(e[b], this)) return !0
            }));
            for (b = 0; c > b; b++) _.find(a, e[b], d);
            return d = this.pushStack(c > 1 ? _.unique(d) : d), d.selector = this.selector ? this.selector + " " + a : a, d
        },
        filter: function(a) {
            return this.pushStack(d(this, a || [], !1))
        },
        not: function(a) {
            return this.pushStack(d(this, a || [], !0))
        },
        is: function(a) {
            return !!d(this, "string" == typeof a && fa.test(a) ? _(a) : a || [], !1).length
        }
    });
    var ia, ja = /^(?:\s*(<[\w\W]+>)[^>]*|#([\w-]*))$/,
        ka = _.fn.init = function(a, b) {
            var c, d;
            if (!a) return this;
            if ("string" == typeof a) {
                if (c = "<" === a[0] && ">" === a[a.length - 1] && a.length >= 3 ? [null, a, null] : ja.exec(a), !c || !c[1] && b) return !b || b.jquery ? (b || ia).find(a) : this.constructor(b).find(a);
                if (c[1]) {
                    if (b = b instanceof _ ? b[0] : b, _.merge(this, _.parseHTML(c[1], b && b.nodeType ? b.ownerDocument || b : Z, !0)), ga.test(c[1]) && _.isPlainObject(b))
                        for (c in b) _.isFunction(this[c]) ? this[c](b[c]) : this.attr(c, b[c]);
                    return this
                }
                return d = Z.getElementById(c[2]), d && d.parentNode && (this.length = 1, this[0] = d), this.context = Z, this.selector = a, this
            }
            return a.nodeType ? (this.context = this[0] = a, this.length = 1, this) : _.isFunction(a) ? "undefined" != typeof ia.ready ? ia.ready(a) : a(_) : (void 0 !== a.selector && (this.selector = a.selector, this.context = a.context), _.makeArray(a, this))
        };
    ka.prototype = _.fn, ia = _(Z);
    var la = /^(?:parents|prev(?:Until|All))/,
        ma = {
            children: !0,
            contents: !0,
            next: !0,
            prev: !0
        };
    _.extend({
        dir: function(a, b, c) {
            for (var d = [], e = void 0 !== c;
                (a = a[b]) && 9 !== a.nodeType;)
                if (1 === a.nodeType) {
                    if (e && _(a).is(c)) break;
                    d.push(a)
                }
            return d
        },
        sibling: function(a, b) {
            for (var c = []; a; a = a.nextSibling) 1 === a.nodeType && a !== b && c.push(a);
            return c
        }
    }), _.fn.extend({
        has: function(a) {
            var b = _(a, this),
                c = b.length;
            return this.filter(function() {
                for (var a = 0; c > a; a++)
                    if (_.contains(this, b[a])) return !0
            })
        },
        closest: function(a, b) {
            for (var c, d = 0, e = this.length, f = [], g = fa.test(a) || "string" != typeof a ? _(a, b || this.context) : 0; e > d; d++)
                for (c = this[d]; c && c !== b; c = c.parentNode)
                    if (c.nodeType < 11 && (g ? g.index(c) > -1 : 1 === c.nodeType && _.find.matchesSelector(c, a))) {
                        f.push(c);
                        break
                    }
            return this.pushStack(f.length > 1 ? _.unique(f) : f)
        },
        index: function(a) {
            return a ? "string" == typeof a ? U.call(_(a), this[0]) : U.call(this, a.jquery ? a[0] : a) : this[0] && this[0].parentNode ? this.first().prevAll().length : -1
        },
        add: function(a, b) {
            return this.pushStack(_.unique(_.merge(this.get(), _(a, b))))
        },
        addBack: function(a) {
            return this.add(null == a ? this.prevObject : this.prevObject.filter(a))
        }
    }), _.each({
        parent: function(a) {
            var b = a.parentNode;
            return b && 11 !== b.nodeType ? b : null
        },
        parents: function(a) {
            return _.dir(a, "parentNode")
        },
        parentsUntil: function(a, b, c) {
            return _.dir(a, "parentNode", c)
        },
        next: function(a) {
            return e(a, "nextSibling")
        },
        prev: function(a) {
            return e(a, "previousSibling")
        },
        nextAll: function(a) {
            return _.dir(a, "nextSibling")
        },
        prevAll: function(a) {
            return _.dir(a, "previousSibling")
        },
        nextUntil: function(a, b, c) {
            return _.dir(a, "nextSibling", c)
        },
        prevUntil: function(a, b, c) {
            return _.dir(a, "previousSibling", c)
        },
        siblings: function(a) {
            return _.sibling((a.parentNode || {}).firstChild, a)
        },
        children: function(a) {
            return _.sibling(a.firstChild)
        },
        contents: function(a) {
            return a.contentDocument || _.merge([], a.childNodes)
        }
    }, function(a, b) {
        _.fn[a] = function(c, d) {
            var e = _.map(this, b, c);
            return "Until" !== a.slice(-5) && (d = c), d && "string" == typeof d && (e = _.filter(d, e)), this.length > 1 && (ma[a] || _.unique(e), la.test(a) && e.reverse()), this.pushStack(e)
        }
    });
    var na = /\S+/g,
        oa = {};
    _.Callbacks = function(a) {
        a = "string" == typeof a ? oa[a] || f(a) : _.extend({}, a);
        var b, c, d, e, g, h, i = [],
            j = !a.once && [],
            k = function(f) {
                for (b = a.memory && f, c = !0, h = e || 0, e = 0, g = i.length, d = !0; i && g > h; h++)
                    if (i[h].apply(f[0], f[1]) === !1 && a.stopOnFalse) {
                        b = !1;
                        break
                    }
                d = !1, i && (j ? j.length && k(j.shift()) : b ? i = [] : l.disable())
            },
            l = {
                add: function() {
                    if (i) {
                        var c = i.length;
                        ! function f(b) {
                            _.each(b, function(b, c) {
                                var d = _.type(c);
                                "function" === d ? a.unique && l.has(c) || i.push(c) : c && c.length && "string" !== d && f(c)
                            })
                        }(arguments), d ? g = i.length : b && (e = c, k(b))
                    }
                    return this
                },
                remove: function() {
                    return i && _.each(arguments, function(a, b) {
                        for (var c;
                            (c = _.inArray(b, i, c)) > -1;) i.splice(c, 1), d && (g >= c && g--, h >= c && h--)
                    }), this
                },
                has: function(a) {
                    return a ? _.inArray(a, i) > -1 : !(!i || !i.length)
                },
                empty: function() {
                    return i = [], g = 0, this
                },
                disable: function() {
                    return i = j = b = void 0, this
                },
                disabled: function() {
                    return !i
                },
                lock: function() {
                    return j = void 0, b || l.disable(), this
                },
                locked: function() {
                    return !j
                },
                fireWith: function(a, b) {
                    return !i || c && !j || (b = b || [], b = [a, b.slice ? b.slice() : b], d ? j.push(b) : k(b)), this
                },
                fire: function() {
                    return l.fireWith(this, arguments), this
                },
                fired: function() {
                    return !!c
                }
            };
        return l
    }, _.extend({
        Deferred: function(a) {
            var b = [
                    ["resolve", "done", _.Callbacks("once memory"), "resolved"],
                    ["reject", "fail", _.Callbacks("once memory"), "rejected"],
                    ["notify", "progress", _.Callbacks("memory")]
                ],
                c = "pending",
                d = {
                    state: function() {
                        return c
                    },
                    always: function() {
                        return e.done(arguments).fail(arguments), this
                    },
                    then: function() {
                        var a = arguments;
                        return _.Deferred(function(c) {
                            _.each(b, function(b, f) {
                                var g = _.isFunction(a[b]) && a[b];
                                e[f[1]](function() {
                                    var a = g && g.apply(this, arguments);
                                    a && _.isFunction(a.promise) ? a.promise().done(c.resolve).fail(c.reject).progress(c.notify) : c[f[0] + "With"](this === d ? c.promise() : this, g ? [a] : arguments)
                                })
                            }), a = null
                        }).promise()
                    },
                    promise: function(a) {
                        return null != a ? _.extend(a, d) : d
                    }
                },
                e = {};
            return d.pipe = d.then, _.each(b, function(a, f) {
                var g = f[2],
                    h = f[3];
                d[f[1]] = g.add, h && g.add(function() {
                    c = h
                }, b[1 ^ a][2].disable, b[2][2].lock), e[f[0]] = function() {
                    return e[f[0] + "With"](this === e ? d : this, arguments), this
                }, e[f[0] + "With"] = g.fireWith
            }), d.promise(e), a && a.call(e, e), e
        },
        when: function(a) {
            var b, c, d, e = 0,
                f = R.call(arguments),
                g = f.length,
                h = 1 !== g || a && _.isFunction(a.promise) ? g : 0,
                i = 1 === h ? a : _.Deferred(),
                j = function(a, c, d) {
                    return function(e) {
                        c[a] = this, d[a] = arguments.length > 1 ? R.call(arguments) : e, d === b ? i.notifyWith(c, d) : --h || i.resolveWith(c, d)
                    }
                };
            if (g > 1)
                for (b = new Array(g), c = new Array(g), d = new Array(g); g > e; e++) f[e] && _.isFunction(f[e].promise) ? f[e].promise().done(j(e, d, f)).fail(i.reject).progress(j(e, c, b)) : --h;
            return h || i.resolveWith(d, f), i.promise()
        }
    });
    var pa;
    _.fn.ready = function(a) {
        return _.ready.promise().done(a), this
    }, _.extend({
        isReady: !1,
        readyWait: 1,
        holdReady: function(a) {
            a ? _.readyWait++ : _.ready(!0)
        },
        ready: function(a) {
            (a === !0 ? --_.readyWait : _.isReady) || (_.isReady = !0, a !== !0 && --_.readyWait > 0 || (pa.resolveWith(Z, [_]), _.fn.triggerHandler && (_(Z).triggerHandler("ready"), _(Z).off("ready"))))
        }
    }), _.ready.promise = function(b) {
        return pa || (pa = _.Deferred(), "complete" === Z.readyState ? setTimeout(_.ready) : (Z.addEventListener("DOMContentLoaded", g, !1), a.addEventListener("load", g, !1))), pa.promise(b)
    }, _.ready.promise();
    var qa = _.access = function(a, b, c, d, e, f, g) {
        var h = 0,
            i = a.length,
            j = null == c;
        if ("object" === _.type(c)) {
            e = !0;
            for (h in c) _.access(a, b, h, c[h], !0, f, g)
        } else if (void 0 !== d && (e = !0, _.isFunction(d) || (g = !0), j && (g ? (b.call(a, d), b = null) : (j = b, b = function(a, b, c) {
                return j.call(_(a), c)
            })), b))
            for (; i > h; h++) b(a[h], c, g ? d : d.call(a[h], h, b(a[h], c)));
        return e ? a : j ? b.call(a) : i ? b(a[0], c) : f
    };
    _.acceptData = function(a) {
        return 1 === a.nodeType || 9 === a.nodeType || !+a.nodeType
    }, h.uid = 1, h.accepts = _.acceptData, h.prototype = {
        key: function(a) {
            if (!h.accepts(a)) return 0;
            var b = {},
                c = a[this.expando];
            if (!c) {
                c = h.uid++;
                try {
                    b[this.expando] = {
                        value: c
                    }, Object.defineProperties(a, b)
                } catch (d) {
                    b[this.expando] = c, _.extend(a, b)
                }
            }
            return this.cache[c] || (this.cache[c] = {}), c
        },
        set: function(a, b, c) {
            var d, e = this.key(a),
                f = this.cache[e];
            if ("string" == typeof b) f[b] = c;
            else if (_.isEmptyObject(f)) _.extend(this.cache[e], b);
            else
                for (d in b) f[d] = b[d];
            return f
        },
        get: function(a, b) {
            var c = this.cache[this.key(a)];
            return void 0 === b ? c : c[b]
        },
        access: function(a, b, c) {
            var d;
            return void 0 === b || b && "string" == typeof b && void 0 === c ? (d = this.get(a, b), void 0 !== d ? d : this.get(a, _.camelCase(b))) : (this.set(a, b, c), void 0 !== c ? c : b)
        },
        remove: function(a, b) {
            var c, d, e, f = this.key(a),
                g = this.cache[f];
            if (void 0 === b) this.cache[f] = {};
            else {
                _.isArray(b) ? d = b.concat(b.map(_.camelCase)) : (e = _.camelCase(b), b in g ? d = [b, e] : (d = e, d = d in g ? [d] : d.match(na) || [])), c = d.length;
                for (; c--;) delete g[d[c]]
            }
        },
        hasData: function(a) {
            return !_.isEmptyObject(this.cache[a[this.expando]] || {})
        },
        discard: function(a) {
            a[this.expando] && delete this.cache[a[this.expando]]
        }
    };
    var ra = new h,
        sa = new h,
        ta = /^(?:\{[\w\W]*\}|\[[\w\W]*\])$/,
        ua = /([A-Z])/g;
    _.extend({
        hasData: function(a) {
            return sa.hasData(a) || ra.hasData(a)
        },
        data: function(a, b, c) {
            return sa.access(a, b, c)
        },
        removeData: function(a, b) {
            sa.remove(a, b)
        },
        _data: function(a, b, c) {
            return ra.access(a, b, c)
        },
        _removeData: function(a, b) {
            ra.remove(a, b)
        }
    }), _.fn.extend({
        data: function(a, b) {
            var c, d, e, f = this[0],
                g = f && f.attributes;
            if (void 0 === a) {
                if (this.length && (e = sa.get(f), 1 === f.nodeType && !ra.get(f, "hasDataAttrs"))) {
                    for (c = g.length; c--;) g[c] && (d = g[c].name, 0 === d.indexOf("data-") && (d = _.camelCase(d.slice(5)), i(f, d, e[d])));
                    ra.set(f, "hasDataAttrs", !0)
                }
                return e
            }
            return "object" == typeof a ? this.each(function() {
                sa.set(this, a)
            }) : qa(this, function(b) {
                var c, d = _.camelCase(a);
                if (f && void 0 === b) {
                    if (c = sa.get(f, a), void 0 !== c) return c;
                    if (c = sa.get(f, d), void 0 !== c) return c;
                    if (c = i(f, d, void 0), void 0 !== c) return c
                } else this.each(function() {
                    var c = sa.get(this, d);
                    sa.set(this, d, b), -1 !== a.indexOf("-") && void 0 !== c && sa.set(this, a, b)
                })
            }, null, b, arguments.length > 1, null, !0)
        },
        removeData: function(a) {
            return this.each(function() {
                sa.remove(this, a)
            })
        }
    }), _.extend({
        queue: function(a, b, c) {
            var d;
            return a ? (b = (b || "fx") + "queue", d = ra.get(a, b), c && (!d || _.isArray(c) ? d = ra.access(a, b, _.makeArray(c)) : d.push(c)), d || []) : void 0
        },
        dequeue: function(a, b) {
            b = b || "fx";
            var c = _.queue(a, b),
                d = c.length,
                e = c.shift(),
                f = _._queueHooks(a, b),
                g = function() {
                    _.dequeue(a, b)
                };
            "inprogress" === e && (e = c.shift(), d--), e && ("fx" === b && c.unshift("inprogress"), delete f.stop, e.call(a, g, f)), !d && f && f.empty.fire()
        },
        _queueHooks: function(a, b) {
            var c = b + "queueHooks";
            return ra.get(a, c) || ra.access(a, c, {
                empty: _.Callbacks("once memory").add(function() {
                    ra.remove(a, [b + "queue", c])
                })
            })
        }
    }), _.fn.extend({
        queue: function(a, b) {
            var c = 2;
            return "string" != typeof a && (b = a, a = "fx", c--), arguments.length < c ? _.queue(this[0], a) : void 0 === b ? this : this.each(function() {
                var c = _.queue(this, a, b);
                _._queueHooks(this, a), "fx" === a && "inprogress" !== c[0] && _.dequeue(this, a)
            })
        },
        dequeue: function(a) {
            return this.each(function() {
                _.dequeue(this, a)
            })
        },
        clearQueue: function(a) {
            return this.queue(a || "fx", [])
        },
        promise: function(a, b) {
            var c, d = 1,
                e = _.Deferred(),
                f = this,
                g = this.length,
                h = function() {
                    --d || e.resolveWith(f, [f])
                };
            for ("string" != typeof a && (b = a, a = void 0), a = a || "fx"; g--;) c = ra.get(f[g], a + "queueHooks"), c && c.empty && (d++, c.empty.add(h));
            return h(), e.promise(b)
        }
    });
    var va = /[+-]?(?:\d*\.|)\d+(?:[eE][+-]?\d+|)/.source,
        wa = ["Top", "Right", "Bottom", "Left"],
        xa = function(a, b) {
            return a = b || a, "none" === _.css(a, "display") || !_.contains(a.ownerDocument, a)
        },
        ya = /^(?:checkbox|radio)$/i;
    ! function() {
        var a = Z.createDocumentFragment(),
            b = a.appendChild(Z.createElement("div")),
            c = Z.createElement("input");
        c.setAttribute("type", "radio"), c.setAttribute("checked", "checked"), c.setAttribute("name", "t"), b.appendChild(c), Y.checkClone = b.cloneNode(!0).cloneNode(!0).lastChild.checked, b.innerHTML = "<textarea>x</textarea>", Y.noCloneChecked = !!b.cloneNode(!0).lastChild.defaultValue
    }();
    var za = "undefined";
    Y.focusinBubbles = "onfocusin" in a;
    var Aa = /^key/,
        Ba = /^(?:mouse|pointer|contextmenu)|click/,
        Ca = /^(?:focusinfocus|focusoutblur)$/,
        Da = /^([^.]*)(?:\.(.+)|)$/;
    _.event = {
        global: {},
        add: function(a, b, c, d, e) {
            var f, g, h, i, j, k, l, m, n, o, p, q = ra.get(a);
            if (q)
                for (c.handler && (f = c, c = f.handler, e = f.selector), c.guid || (c.guid = _.guid++), (i = q.events) || (i = q.events = {}), (g = q.handle) || (g = q.handle = function(b) {
                        return typeof _ !== za && _.event.triggered !== b.type ? _.event.dispatch.apply(a, arguments) : void 0
                    }), b = (b || "").match(na) || [""], j = b.length; j--;) h = Da.exec(b[j]) || [], n = p = h[1], o = (h[2] || "").split(".").sort(), n && (l = _.event.special[n] || {}, n = (e ? l.delegateType : l.bindType) || n, l = _.event.special[n] || {}, k = _.extend({
                    type: n,
                    origType: p,
                    data: d,
                    handler: c,
                    guid: c.guid,
                    selector: e,
                    needsContext: e && _.expr.match.needsContext.test(e),
                    namespace: o.join(".")
                }, f), (m = i[n]) || (m = i[n] = [], m.delegateCount = 0, l.setup && l.setup.call(a, d, o, g) !== !1 || a.addEventListener && a.addEventListener(n, g, !1)), l.add && (l.add.call(a, k), k.handler.guid || (k.handler.guid = c.guid)), e ? m.splice(m.delegateCount++, 0, k) : m.push(k), _.event.global[n] = !0)
        },
        remove: function(a, b, c, d, e) {
            var f, g, h, i, j, k, l, m, n, o, p, q = ra.hasData(a) && ra.get(a);
            if (q && (i = q.events)) {
                for (b = (b || "").match(na) || [""], j = b.length; j--;)
                    if (h = Da.exec(b[j]) || [], n = p = h[1], o = (h[2] || "").split(".").sort(), n) {
                        for (l = _.event.special[n] || {}, n = (d ? l.delegateType : l.bindType) || n, m = i[n] || [], h = h[2] && new RegExp("(^|\\.)" + o.join("\\.(?:.*\\.|)") + "(\\.|$)"), g = f = m.length; f--;) k = m[f], !e && p !== k.origType || c && c.guid !== k.guid || h && !h.test(k.namespace) || d && d !== k.selector && ("**" !== d || !k.selector) || (m.splice(f, 1), k.selector && m.delegateCount--, l.remove && l.remove.call(a, k));
                        g && !m.length && (l.teardown && l.teardown.call(a, o, q.handle) !== !1 || _.removeEvent(a, n, q.handle), delete i[n])
                    } else
                        for (n in i) _.event.remove(a, n + b[j], c, d, !0);
                _.isEmptyObject(i) && (delete q.handle, ra.remove(a, "events"))
            }
        },
        trigger: function(b, c, d, e) {
            var f, g, h, i, j, k, l, m = [d || Z],
                n = X.call(b, "type") ? b.type : b,
                o = X.call(b, "namespace") ? b.namespace.split(".") : [];
            if (g = h = d = d || Z, 3 !== d.nodeType && 8 !== d.nodeType && !Ca.test(n + _.event.triggered) && (n.indexOf(".") >= 0 && (o = n.split("."), n = o.shift(), o.sort()), j = n.indexOf(":") < 0 && "on" + n, b = b[_.expando] ? b : new _.Event(n, "object" == typeof b && b), b.isTrigger = e ? 2 : 3, b.namespace = o.join("."), b.namespace_re = b.namespace ? new RegExp("(^|\\.)" + o.join("\\.(?:.*\\.|)") + "(\\.|$)") : null, b.result = void 0, b.target || (b.target = d), c = null == c ? [b] : _.makeArray(c, [b]), l = _.event.special[n] || {}, e || !l.trigger || l.trigger.apply(d, c) !== !1)) {
                if (!e && !l.noBubble && !_.isWindow(d)) {
                    for (i = l.delegateType || n, Ca.test(i + n) || (g = g.parentNode); g; g = g.parentNode) m.push(g), h = g;
                    h === (d.ownerDocument || Z) && m.push(h.defaultView || h.parentWindow || a)
                }
                for (f = 0;
                    (g = m[f++]) && !b.isPropagationStopped();) b.type = f > 1 ? i : l.bindType || n, k = (ra.get(g, "events") || {})[b.type] && ra.get(g, "handle"), k && k.apply(g, c), k = j && g[j], k && k.apply && _.acceptData(g) && (b.result = k.apply(g, c), b.result === !1 && b.preventDefault());
                return b.type = n, e || b.isDefaultPrevented() || l._default && l._default.apply(m.pop(), c) !== !1 || !_.acceptData(d) || j && _.isFunction(d[n]) && !_.isWindow(d) && (h = d[j], h && (d[j] = null), _.event.triggered = n, d[n](), _.event.triggered = void 0, h && (d[j] = h)), b.result
            }
        },
        dispatch: function(a) {
            a = _.event.fix(a);
            var b, c, d, e, f, g = [],
                h = R.call(arguments),
                i = (ra.get(this, "events") || {})[a.type] || [],
                j = _.event.special[a.type] || {};
            if (h[0] = a, a.delegateTarget = this, !j.preDispatch || j.preDispatch.call(this, a) !== !1) {
                for (g = _.event.handlers.call(this, a, i), b = 0;
                    (e = g[b++]) && !a.isPropagationStopped();)
                    for (a.currentTarget = e.elem, c = 0;
                        (f = e.handlers[c++]) && !a.isImmediatePropagationStopped();)(!a.namespace_re || a.namespace_re.test(f.namespace)) && (a.handleObj = f, a.data = f.data, d = ((_.event.special[f.origType] || {}).handle || f.handler).apply(e.elem, h), void 0 !== d && (a.result = d) === !1 && (a.preventDefault(), a.stopPropagation()));
                return j.postDispatch && j.postDispatch.call(this, a), a.result
            }
        },
        handlers: function(a, b) {
            var c, d, e, f, g = [],
                h = b.delegateCount,
                i = a.target;
            if (h && i.nodeType && (!a.button || "click" !== a.type))
                for (; i !== this; i = i.parentNode || this)
                    if (i.disabled !== !0 || "click" !== a.type) {
                        for (d = [], c = 0; h > c; c++) f = b[c], e = f.selector + " ", void 0 === d[e] && (d[e] = f.needsContext ? _(e, this).index(i) >= 0 : _.find(e, this, null, [i]).length), d[e] && d.push(f);
                        d.length && g.push({
                            elem: i,
                            handlers: d
                        })
                    }
            return h < b.length && g.push({
                elem: this,
                handlers: b.slice(h)
            }), g
        },
        props: "altKey bubbles cancelable ctrlKey currentTarget eventPhase metaKey relatedTarget shiftKey target timeStamp view which".split(" "),
        fixHooks: {},
        keyHooks: {
            props: "char charCode key keyCode".split(" "),
            filter: function(a, b) {
                return null == a.which && (a.which = null != b.charCode ? b.charCode : b.keyCode), a
            }
        },
        mouseHooks: {
            props: "button buttons clientX clientY offsetX offsetY pageX pageY screenX screenY toElement".split(" "),
            filter: function(a, b) {
                var c, d, e, f = b.button;
                return null == a.pageX && null != b.clientX && (c = a.target.ownerDocument || Z, d = c.documentElement, e = c.body, a.pageX = b.clientX + (d && d.scrollLeft || e && e.scrollLeft || 0) - (d && d.clientLeft || e && e.clientLeft || 0), a.pageY = b.clientY + (d && d.scrollTop || e && e.scrollTop || 0) - (d && d.clientTop || e && e.clientTop || 0)), a.which || void 0 === f || (a.which = 1 & f ? 1 : 2 & f ? 3 : 4 & f ? 2 : 0), a
            }
        },
        fix: function(a) {
            if (a[_.expando]) return a;
            var b, c, d, e = a.type,
                f = a,
                g = this.fixHooks[e];
            for (g || (this.fixHooks[e] = g = Ba.test(e) ? this.mouseHooks : Aa.test(e) ? this.keyHooks : {}), d = g.props ? this.props.concat(g.props) : this.props, a = new _.Event(f), b = d.length; b--;) c = d[b], a[c] = f[c];
            return a.target || (a.target = Z), 3 === a.target.nodeType && (a.target = a.target.parentNode), g.filter ? g.filter(a, f) : a
        },
        special: {
            load: {
                noBubble: !0
            },
            focus: {
                trigger: function() {
                    return this !== l() && this.focus ? (this.focus(), !1) : void 0
                },
                delegateType: "focusin"
            },
            blur: {
                trigger: function() {
                    return this === l() && this.blur ? (this.blur(), !1) : void 0
                },
                delegateType: "focusout"
            },
            click: {
                trigger: function() {
                    return "checkbox" === this.type && this.click && _.nodeName(this, "input") ? (this.click(), !1) : void 0
                },
                _default: function(a) {
                    return _.nodeName(a.target, "a")
                }
            },
            beforeunload: {
                postDispatch: function(a) {
                    void 0 !== a.result && a.originalEvent && (a.originalEvent.returnValue = a.result)
                }
            }
        },
        simulate: function(a, b, c, d) {
            var e = _.extend(new _.Event, c, {
                type: a,
                isSimulated: !0,
                originalEvent: {}
            });
            d ? _.event.trigger(e, null, b) : _.event.dispatch.call(b, e), e.isDefaultPrevented() && c.preventDefault()
        }
    }, _.removeEvent = function(a, b, c) {
        a.removeEventListener && a.removeEventListener(b, c, !1)
    }, _.Event = function(a, b) {
        return this instanceof _.Event ? (a && a.type ? (this.originalEvent = a, this.type = a.type, this.isDefaultPrevented = a.defaultPrevented || void 0 === a.defaultPrevented && a.returnValue === !1 ? j : k) : this.type = a, b && _.extend(this, b), this.timeStamp = a && a.timeStamp || _.now(), void(this[_.expando] = !0)) : new _.Event(a, b)
    }, _.Event.prototype = {
        isDefaultPrevented: k,
        isPropagationStopped: k,
        isImmediatePropagationStopped: k,
        preventDefault: function() {
            var a = this.originalEvent;
            this.isDefaultPrevented = j, a && a.preventDefault && a.preventDefault()
        },
        stopPropagation: function() {
            var a = this.originalEvent;
            this.isPropagationStopped = j, a && a.stopPropagation && a.stopPropagation()
        },
        stopImmediatePropagation: function() {
            var a = this.originalEvent;
            this.isImmediatePropagationStopped = j, a && a.stopImmediatePropagation && a.stopImmediatePropagation(), this.stopPropagation()
        }
    }, _.each({
        mouseenter: "mouseover",
        mouseleave: "mouseout",
        pointerenter: "pointerover",
        pointerleave: "pointerout"
    }, function(a, b) {
        _.event.special[a] = {
            delegateType: b,
            bindType: b,
            handle: function(a) {
                var c, d = this,
                    e = a.relatedTarget,
                    f = a.handleObj;
                return (!e || e !== d && !_.contains(d, e)) && (a.type = f.origType, c = f.handler.apply(this, arguments), a.type = b), c
            }
        }
    }), Y.focusinBubbles || _.each({
        focus: "focusin",
        blur: "focusout"
    }, function(a, b) {
        var c = function(a) {
            _.event.simulate(b, a.target, _.event.fix(a), !0)
        };
        _.event.special[b] = {
            setup: function() {
                var d = this.ownerDocument || this,
                    e = ra.access(d, b);
                e || d.addEventListener(a, c, !0), ra.access(d, b, (e || 0) + 1)
            },
            teardown: function() {
                var d = this.ownerDocument || this,
                    e = ra.access(d, b) - 1;
                e ? ra.access(d, b, e) : (d.removeEventListener(a, c, !0), ra.remove(d, b))
            }
        }
    }), _.fn.extend({
        on: function(a, b, c, d, e) {
            var f, g;
            if ("object" == typeof a) {
                "string" != typeof b && (c = c || b, b = void 0);
                for (g in a) this.on(g, b, c, a[g], e);
                return this
            }
            if (null == c && null == d ? (d = b, c = b = void 0) : null == d && ("string" == typeof b ? (d = c, c = void 0) : (d = c, c = b, b = void 0)), d === !1) d = k;
            else if (!d) return this;
            return 1 === e && (f = d, d = function(a) {
                return _().off(a), f.apply(this, arguments)
            }, d.guid = f.guid || (f.guid = _.guid++)), this.each(function() {
                _.event.add(this, a, d, c, b)
            })
        },
        one: function(a, b, c, d) {
            return this.on(a, b, c, d, 1)
        },
        off: function(a, b, c) {
            var d, e;
            if (a && a.preventDefault && a.handleObj) return d = a.handleObj, _(a.delegateTarget).off(d.namespace ? d.origType + "." + d.namespace : d.origType, d.selector, d.handler), this;
            if ("object" == typeof a) {
                for (e in a) this.off(e, b, a[e]);
                return this
            }
            return (b === !1 || "function" == typeof b) && (c = b, b = void 0), c === !1 && (c = k), this.each(function() {
                _.event.remove(this, a, c, b)
            })
        },
        trigger: function(a, b) {
            return this.each(function() {
                _.event.trigger(a, b, this)
            })
        },
        triggerHandler: function(a, b) {
            var c = this[0];
            return c ? _.event.trigger(a, b, c, !0) : void 0
        }
    });
    var Ea = /<(?!area|br|col|embed|hr|img|input|link|meta|param)(([\w:]+)[^>]*)\/>/gi,
        Fa = /<([\w:]+)/,
        Ga = /<|&#?\w+;/,
        Ha = /<(?:script|style|link)/i,
        Ia = /checked\s*(?:[^=]|=\s*.checked.)/i,
        Ja = /^$|\/(?:java|ecma)script/i,
        Ka = /^true\/(.*)/,
        La = /^\s*<!(?:\[CDATA\[|--)|(?:\]\]|--)>\s*$/g,
        Ma = {
            option: [1, "<select multiple='multiple'>", "</select>"],
            thead: [1, "<table>", "</table>"],
            col: [2, "<table><colgroup>", "</colgroup></table>"],
            tr: [2, "<table><tbody>", "</tbody></table>"],
            td: [3, "<table><tbody><tr>", "</tr></tbody></table>"],
            _default: [0, "", ""]
        };
    Ma.optgroup = Ma.option, Ma.tbody = Ma.tfoot = Ma.colgroup = Ma.caption = Ma.thead, Ma.th = Ma.td, _.extend({
        clone: function(a, b, c) {
            var d, e, f, g, h = a.cloneNode(!0),
                i = _.contains(a.ownerDocument, a);
            if (!(Y.noCloneChecked || 1 !== a.nodeType && 11 !== a.nodeType || _.isXMLDoc(a)))
                for (g = r(h), f = r(a), d = 0, e = f.length; e > d; d++) s(f[d], g[d]);
            if (b)
                if (c)
                    for (f = f || r(a), g = g || r(h), d = 0, e = f.length; e > d; d++) q(f[d], g[d]);
                else q(a, h);
            return g = r(h, "script"), g.length > 0 && p(g, !i && r(a, "script")), h
        },
        buildFragment: function(a, b, c, d) {
            for (var e, f, g, h, i, j, k = b.createDocumentFragment(), l = [], m = 0, n = a.length; n > m; m++)
                if (e = a[m], e || 0 === e)
                    if ("object" === _.type(e)) _.merge(l, e.nodeType ? [e] : e);
                    else if (Ga.test(e)) {
                for (f = f || k.appendChild(b.createElement("div")), g = (Fa.exec(e) || ["", ""])[1].toLowerCase(), h = Ma[g] || Ma._default, f.innerHTML = h[1] + e.replace(Ea, "<$1></$2>") + h[2], j = h[0]; j--;) f = f.lastChild;
                _.merge(l, f.childNodes), f = k.firstChild, f.textContent = ""
            } else l.push(b.createTextNode(e));
            for (k.textContent = "", m = 0; e = l[m++];)
                if ((!d || -1 === _.inArray(e, d)) && (i = _.contains(e.ownerDocument, e), f = r(k.appendChild(e), "script"), i && p(f), c))
                    for (j = 0; e = f[j++];) Ja.test(e.type || "") && c.push(e);
            return k
        },
        cleanData: function(a) {
            for (var b, c, d, e, f = _.event.special, g = 0; void 0 !== (c = a[g]); g++) {
                if (_.acceptData(c) && (e = c[ra.expando], e && (b = ra.cache[e]))) {
                    if (b.events)
                        for (d in b.events) f[d] ? _.event.remove(c, d) : _.removeEvent(c, d, b.handle);
                    ra.cache[e] && delete ra.cache[e]
                }
                delete sa.cache[c[sa.expando]]
            }
        }
    }), _.fn.extend({
        text: function(a) {
            return qa(this, function(a) {
                return void 0 === a ? _.text(this) : this.empty().each(function() {
                    (1 === this.nodeType || 11 === this.nodeType || 9 === this.nodeType) && (this.textContent = a)
                })
            }, null, a, arguments.length)
        },
        append: function() {
            return this.domManip(arguments, function(a) {
                if (1 === this.nodeType || 11 === this.nodeType || 9 === this.nodeType) {
                    var b = m(this, a);
                    b.appendChild(a)
                }
            })
        },
        prepend: function() {
            return this.domManip(arguments, function(a) {
                if (1 === this.nodeType || 11 === this.nodeType || 9 === this.nodeType) {
                    var b = m(this, a);
                    b.insertBefore(a, b.firstChild)
                }
            })
        },
        before: function() {
            return this.domManip(arguments, function(a) {
                this.parentNode && this.parentNode.insertBefore(a, this)
            })
        },
        after: function() {
            return this.domManip(arguments, function(a) {
                this.parentNode && this.parentNode.insertBefore(a, this.nextSibling)
            })
        },
        remove: function(a, b) {
            for (var c, d = a ? _.filter(a, this) : this, e = 0; null != (c = d[e]); e++) b || 1 !== c.nodeType || _.cleanData(r(c)), c.parentNode && (b && _.contains(c.ownerDocument, c) && p(r(c, "script")), c.parentNode.removeChild(c));
            return this
        },
        empty: function() {
            for (var a, b = 0; null != (a = this[b]); b++) 1 === a.nodeType && (_.cleanData(r(a, !1)), a.textContent = "");
            return this
        },
        clone: function(a, b) {
            return a = null == a ? !1 : a, b = null == b ? a : b, this.map(function() {
                return _.clone(this, a, b)
            })
        },
        html: function(a) {
            return qa(this, function(a) {
                var b = this[0] || {},
                    c = 0,
                    d = this.length;
                if (void 0 === a && 1 === b.nodeType) return b.innerHTML;
                if ("string" == typeof a && !Ha.test(a) && !Ma[(Fa.exec(a) || ["", ""])[1].toLowerCase()]) {
                    a = a.replace(Ea, "<$1></$2>");
                    try {
                        for (; d > c; c++) b = this[c] || {}, 1 === b.nodeType && (_.cleanData(r(b, !1)), b.innerHTML = a);
                        b = 0
                    } catch (e) {}
                }
                b && this.empty().append(a)
            }, null, a, arguments.length)
        },
        replaceWith: function() {
            var a = arguments[0];
            return this.domManip(arguments, function(b) {
                a = this.parentNode, _.cleanData(r(this)), a && a.replaceChild(b, this)
            }), a && (a.length || a.nodeType) ? this : this.remove()
        },
        detach: function(a) {
            return this.remove(a, !0)
        },
        domManip: function(a, b) {
            a = S.apply([], a);
            var c, d, e, f, g, h, i = 0,
                j = this.length,
                k = this,
                l = j - 1,
                m = a[0],
                p = _.isFunction(m);
            if (p || j > 1 && "string" == typeof m && !Y.checkClone && Ia.test(m)) return this.each(function(c) {
                var d = k.eq(c);
                p && (a[0] = m.call(this, c, d.html())), d.domManip(a, b)
            });
            if (j && (c = _.buildFragment(a, this[0].ownerDocument, !1, this), d = c.firstChild, 1 === c.childNodes.length && (c = d), d)) {
                for (e = _.map(r(c, "script"), n), f = e.length; j > i; i++) g = c, i !== l && (g = _.clone(g, !0, !0), f && _.merge(e, r(g, "script"))), b.call(this[i], g, i);
                if (f)
                    for (h = e[e.length - 1].ownerDocument, _.map(e, o), i = 0; f > i; i++) g = e[i], Ja.test(g.type || "") && !ra.access(g, "globalEval") && _.contains(h, g) && (g.src ? _._evalUrl && _._evalUrl(g.src) : _.globalEval(g.textContent.replace(La, "")))
            }
            return this
        }
    }), _.each({
        appendTo: "append",
        prependTo: "prepend",
        insertBefore: "before",
        insertAfter: "after",
        replaceAll: "replaceWith"
    }, function(a, b) {
        _.fn[a] = function(a) {
            for (var c, d = [], e = _(a), f = e.length - 1, g = 0; f >= g; g++) c = g === f ? this : this.clone(!0), _(e[g])[b](c), T.apply(d, c.get());
            return this.pushStack(d)
        }
    });
    var Na, Oa = {},
        Pa = /^margin/,
        Qa = new RegExp("^(" + va + ")(?!px)[a-z%]+$", "i"),
        Ra = function(b) {
            return b.ownerDocument.defaultView.opener ? b.ownerDocument.defaultView.getComputedStyle(b, null) : a.getComputedStyle(b, null)
        };
    ! function() {
        function b() {
            g.style.cssText = "-webkit-box-sizing:border-box;-moz-box-sizing:border-box;box-sizing:border-box;display:block;margin-top:1%;top:1%;border:1px;padding:1px;width:4px;position:absolute", g.innerHTML = "", e.appendChild(f);
            var b = a.getComputedStyle(g, null);
            c = "1%" !== b.top, d = "4px" === b.width, e.removeChild(f)
        }
        var c, d, e = Z.documentElement,
            f = Z.createElement("div"),
            g = Z.createElement("div");
        g.style && (g.style.backgroundClip = "content-box", g.cloneNode(!0).style.backgroundClip = "", Y.clearCloneStyle = "content-box" === g.style.backgroundClip, f.style.cssText = "border:0;width:0;height:0;top:0;left:-9999px;margin-top:1px;position:absolute", f.appendChild(g), a.getComputedStyle && _.extend(Y, {
            pixelPosition: function() {
                return b(), c
            },
            boxSizingReliable: function() {
                return null == d && b(), d
            },
            reliableMarginRight: function() {
                var b, c = g.appendChild(Z.createElement("div"));
                return c.style.cssText = g.style.cssText = "-webkit-box-sizing:content-box;-moz-box-sizing:content-box;box-sizing:content-box;display:block;margin:0;border:0;padding:0", c.style.marginRight = c.style.width = "0", g.style.width = "1px", e.appendChild(f), b = !parseFloat(a.getComputedStyle(c, null).marginRight), e.removeChild(f), g.removeChild(c), b
            }
        }))
    }(), _.swap = function(a, b, c, d) {
        var e, f, g = {};
        for (f in b) g[f] = a.style[f], a.style[f] = b[f];
        e = c.apply(a, d || []);
        for (f in b) a.style[f] = g[f];
        return e
    };
    var Sa = /^(none|table(?!-c[ea]).+)/,
        Ta = new RegExp("^(" + va + ")(.*)$", "i"),
        Ua = new RegExp("^([+-])=(" + va + ")", "i"),
        Va = {
            position: "absolute",
            visibility: "hidden",
            display: "block"
        },
        Wa = {
            letterSpacing: "0",
            fontWeight: "400"
        },
        Xa = ["Webkit", "O", "Moz", "ms"];
    _.extend({
        cssHooks: {
            opacity: {
                get: function(a, b) {
                    if (b) {
                        var c = v(a, "opacity");
                        return "" === c ? "1" : c
                    }
                }
            }
        },
        cssNumber: {
            columnCount: !0,
            fillOpacity: !0,
            flexGrow: !0,
            flexShrink: !0,
            fontWeight: !0,
            lineHeight: !0,
            opacity: !0,
            order: !0,
            orphans: !0,
            widows: !0,
            zIndex: !0,
            zoom: !0
        },
        cssProps: {
            "float": "cssFloat"
        },
        style: function(a, b, c, d) {
            if (a && 3 !== a.nodeType && 8 !== a.nodeType && a.style) {
                var e, f, g, h = _.camelCase(b),
                    i = a.style;
                return b = _.cssProps[h] || (_.cssProps[h] = x(i, h)), g = _.cssHooks[b] || _.cssHooks[h], void 0 === c ? g && "get" in g && void 0 !== (e = g.get(a, !1, d)) ? e : i[b] : (f = typeof c, "string" === f && (e = Ua.exec(c)) && (c = (e[1] + 1) * e[2] + parseFloat(_.css(a, b)), f = "number"), void(null != c && c === c && ("number" !== f || _.cssNumber[h] || (c += "px"), Y.clearCloneStyle || "" !== c || 0 !== b.indexOf("background") || (i[b] = "inherit"), g && "set" in g && void 0 === (c = g.set(a, c, d)) || (i[b] = c))))
            }
        },
        css: function(a, b, c, d) {
            var e, f, g, h = _.camelCase(b);
            return b = _.cssProps[h] || (_.cssProps[h] = x(a.style, h)), g = _.cssHooks[b] || _.cssHooks[h], g && "get" in g && (e = g.get(a, !0, c)), void 0 === e && (e = v(a, b, d)), "normal" === e && b in Wa && (e = Wa[b]), "" === c || c ? (f = parseFloat(e), c === !0 || _.isNumeric(f) ? f || 0 : e) : e
        }
    }), _.each(["height", "width"], function(a, b) {
        _.cssHooks[b] = {
            get: function(a, c, d) {
                return c ? Sa.test(_.css(a, "display")) && 0 === a.offsetWidth ? _.swap(a, Va, function() {
                    return A(a, b, d)
                }) : A(a, b, d) : void 0
            },
            set: function(a, c, d) {
                var e = d && Ra(a);
                return y(a, c, d ? z(a, b, d, "border-box" === _.css(a, "boxSizing", !1, e), e) : 0)
            }
        }
    }), _.cssHooks.marginRight = w(Y.reliableMarginRight, function(a, b) {
        return b ? _.swap(a, {
            display: "inline-block"
        }, v, [a, "marginRight"]) : void 0
    }), _.each({
        margin: "",
        padding: "",
        border: "Width"
    }, function(a, b) {
        _.cssHooks[a + b] = {
            expand: function(c) {
                for (var d = 0, e = {}, f = "string" == typeof c ? c.split(" ") : [c]; 4 > d; d++) e[a + wa[d] + b] = f[d] || f[d - 2] || f[0];
                return e
            }
        }, Pa.test(a) || (_.cssHooks[a + b].set = y)
    }), _.fn.extend({
        css: function(a, b) {
            return qa(this, function(a, b, c) {
                var d, e, f = {},
                    g = 0;
                if (_.isArray(b)) {
                    for (d = Ra(a), e = b.length; e > g; g++) f[b[g]] = _.css(a, b[g], !1, d);
                    return f
                }
                return void 0 !== c ? _.style(a, b, c) : _.css(a, b)
            }, a, b, arguments.length > 1)
        },
        show: function() {
            return B(this, !0)
        },
        hide: function() {
            return B(this)
        },
        toggle: function(a) {
            return "boolean" == typeof a ? a ? this.show() : this.hide() : this.each(function() {
                xa(this) ? _(this).show() : _(this).hide()
            })
        }
    }), _.Tween = C, C.prototype = {
        constructor: C,
        init: function(a, b, c, d, e, f) {
            this.elem = a, this.prop = c, this.easing = e || "swing", this.options = b, this.start = this.now = this.cur(), this.end = d, this.unit = f || (_.cssNumber[c] ? "" : "px")
        },
        cur: function() {
            var a = C.propHooks[this.prop];
            return a && a.get ? a.get(this) : C.propHooks._default.get(this)
        },
        run: function(a) {
            var b, c = C.propHooks[this.prop];
            return this.options.duration ? this.pos = b = _.easing[this.easing](a, this.options.duration * a, 0, 1, this.options.duration) : this.pos = b = a, this.now = (this.end - this.start) * b + this.start, this.options.step && this.options.step.call(this.elem, this.now, this), c && c.set ? c.set(this) : C.propHooks._default.set(this), this
        }
    }, C.prototype.init.prototype = C.prototype, C.propHooks = {
        _default: {
            get: function(a) {
                var b;
                return null == a.elem[a.prop] || a.elem.style && null != a.elem.style[a.prop] ? (b = _.css(a.elem, a.prop, ""), b && "auto" !== b ? b : 0) : a.elem[a.prop]
            },
            set: function(a) {
                _.fx.step[a.prop] ? _.fx.step[a.prop](a) : a.elem.style && (null != a.elem.style[_.cssProps[a.prop]] || _.cssHooks[a.prop]) ? _.style(a.elem, a.prop, a.now + a.unit) : a.elem[a.prop] = a.now
            }
        }
    }, C.propHooks.scrollTop = C.propHooks.scrollLeft = {
        set: function(a) {
            a.elem.nodeType && a.elem.parentNode && (a.elem[a.prop] = a.now)
        }
    }, _.easing = {
        linear: function(a) {
            return a
        },
        swing: function(a) {
            return .5 - Math.cos(a * Math.PI) / 2
        }
    }, _.fx = C.prototype.init, _.fx.step = {};
    var Ya, Za, $a = /^(?:toggle|show|hide)$/,
        _a = new RegExp("^(?:([+-])=|)(" + va + ")([a-z%]*)$", "i"),
        ab = /queueHooks$/,
        bb = [G],
        cb = {
            "*": [function(a, b) {
                var c = this.createTween(a, b),
                    d = c.cur(),
                    e = _a.exec(b),
                    f = e && e[3] || (_.cssNumber[a] ? "" : "px"),
                    g = (_.cssNumber[a] || "px" !== f && +d) && _a.exec(_.css(c.elem, a)),
                    h = 1,
                    i = 20;
                if (g && g[3] !== f) {
                    f = f || g[3], e = e || [], g = +d || 1;
                    do h = h || ".5", g /= h, _.style(c.elem, a, g + f); while (h !== (h = c.cur() / d) && 1 !== h && --i)
                }
                return e && (g = c.start = +g || +d || 0, c.unit = f, c.end = e[1] ? g + (e[1] + 1) * e[2] : +e[2]), c
            }]
        };
    _.Animation = _.extend(I, {
            tweener: function(a, b) {
                _.isFunction(a) ? (b = a, a = ["*"]) : a = a.split(" ");
                for (var c, d = 0, e = a.length; e > d; d++) c = a[d], cb[c] = cb[c] || [], cb[c].unshift(b)
            },
            prefilter: function(a, b) {
                b ? bb.unshift(a) : bb.push(a)
            }
        }), _.speed = function(a, b, c) {
            var d = a && "object" == typeof a ? _.extend({}, a) : {
                complete: c || !c && b || _.isFunction(a) && a,
                duration: a,
                easing: c && b || b && !_.isFunction(b) && b
            };
            return d.duration = _.fx.off ? 0 : "number" == typeof d.duration ? d.duration : d.duration in _.fx.speeds ? _.fx.speeds[d.duration] : _.fx.speeds._default, (null == d.queue || d.queue === !0) && (d.queue = "fx"), d.old = d.complete, d.complete = function() {
                _.isFunction(d.old) && d.old.call(this), d.queue && _.dequeue(this, d.queue)
            }, d
        }, _.fn.extend({
            fadeTo: function(a, b, c, d) {
                return this.filter(xa).css("opacity", 0).show().end().animate({
                    opacity: b
                }, a, c, d)
            },
            animate: function(a, b, c, d) {
                var e = _.isEmptyObject(a),
                    f = _.speed(b, c, d),
                    g = function() {
                        var b = I(this, _.extend({}, a), f);
                        (e || ra.get(this, "finish")) && b.stop(!0)
                    };
                return g.finish = g, e || f.queue === !1 ? this.each(g) : this.queue(f.queue, g)
            },
            stop: function(a, b, c) {
                var d = function(a) {
                    var b = a.stop;
                    delete a.stop, b(c)
                };
                return "string" != typeof a && (c = b, b = a, a = void 0), b && a !== !1 && this.queue(a || "fx", []), this.each(function() {
                    var b = !0,
                        e = null != a && a + "queueHooks",
                        f = _.timers,
                        g = ra.get(this);
                    if (e) g[e] && g[e].stop && d(g[e]);
                    else
                        for (e in g) g[e] && g[e].stop && ab.test(e) && d(g[e]);
                    for (e = f.length; e--;) f[e].elem !== this || null != a && f[e].queue !== a || (f[e].anim.stop(c), b = !1, f.splice(e, 1));
                    (b || !c) && _.dequeue(this, a)
                })
            },
            finish: function(a) {
                return a !== !1 && (a = a || "fx"), this.each(function() {
                    var b, c = ra.get(this),
                        d = c[a + "queue"],
                        e = c[a + "queueHooks"],
                        f = _.timers,
                        g = d ? d.length : 0;
                    for (c.finish = !0, _.queue(this, a, []),
                        e && e.stop && e.stop.call(this, !0), b = f.length; b--;) f[b].elem === this && f[b].queue === a && (f[b].anim.stop(!0), f.splice(b, 1));
                    for (b = 0; g > b; b++) d[b] && d[b].finish && d[b].finish.call(this);
                    delete c.finish
                })
            }
        }), _.each(["toggle", "show", "hide"], function(a, b) {
            var c = _.fn[b];
            _.fn[b] = function(a, d, e) {
                return null == a || "boolean" == typeof a ? c.apply(this, arguments) : this.animate(E(b, !0), a, d, e)
            }
        }), _.each({
            slideDown: E("show"),
            slideUp: E("hide"),
            slideToggle: E("toggle"),
            fadeIn: {
                opacity: "show"
            },
            fadeOut: {
                opacity: "hide"
            },
            fadeToggle: {
                opacity: "toggle"
            }
        }, function(a, b) {
            _.fn[a] = function(a, c, d) {
                return this.animate(b, a, c, d)
            }
        }), _.timers = [], _.fx.tick = function() {
            var a, b = 0,
                c = _.timers;
            for (Ya = _.now(); b < c.length; b++) a = c[b], a() || c[b] !== a || c.splice(b--, 1);
            c.length || _.fx.stop(), Ya = void 0
        }, _.fx.timer = function(a) {
            _.timers.push(a), a() ? _.fx.start() : _.timers.pop()
        }, _.fx.interval = 13, _.fx.start = function() {
            Za || (Za = setInterval(_.fx.tick, _.fx.interval))
        }, _.fx.stop = function() {
            clearInterval(Za), Za = null
        }, _.fx.speeds = {
            slow: 600,
            fast: 200,
            _default: 400
        }, _.fn.delay = function(a, b) {
            return a = _.fx ? _.fx.speeds[a] || a : a, b = b || "fx", this.queue(b, function(b, c) {
                var d = setTimeout(b, a);
                c.stop = function() {
                    clearTimeout(d)
                }
            })
        },
        function() {
            var a = Z.createElement("input"),
                b = Z.createElement("select"),
                c = b.appendChild(Z.createElement("option"));
            a.type = "checkbox", Y.checkOn = "" !== a.value, Y.optSelected = c.selected, b.disabled = !0, Y.optDisabled = !c.disabled, a = Z.createElement("input"), a.value = "t", a.type = "radio", Y.radioValue = "t" === a.value
        }();
    var db, eb, fb = _.expr.attrHandle;
    _.fn.extend({
        attr: function(a, b) {
            return qa(this, _.attr, a, b, arguments.length > 1)
        },
        removeAttr: function(a) {
            return this.each(function() {
                _.removeAttr(this, a)
            })
        }
    }), _.extend({
        attr: function(a, b, c) {
            var d, e, f = a.nodeType;
            return a && 3 !== f && 8 !== f && 2 !== f ? typeof a.getAttribute === za ? _.prop(a, b, c) : (1 === f && _.isXMLDoc(a) || (b = b.toLowerCase(), d = _.attrHooks[b] || (_.expr.match.bool.test(b) ? eb : db)), void 0 === c ? d && "get" in d && null !== (e = d.get(a, b)) ? e : (e = _.find.attr(a, b), null == e ? void 0 : e) : null !== c ? d && "set" in d && void 0 !== (e = d.set(a, c, b)) ? e : (a.setAttribute(b, c + ""), c) : void _.removeAttr(a, b)) : void 0
        },
        removeAttr: function(a, b) {
            var c, d, e = 0,
                f = b && b.match(na);
            if (f && 1 === a.nodeType)
                for (; c = f[e++];) d = _.propFix[c] || c, _.expr.match.bool.test(c) && (a[d] = !1), a.removeAttribute(c)
        },
        attrHooks: {
            type: {
                set: function(a, b) {
                    if (!Y.radioValue && "radio" === b && _.nodeName(a, "input")) {
                        var c = a.value;
                        return a.setAttribute("type", b), c && (a.value = c), b
                    }
                }
            }
        }
    }), eb = {
        set: function(a, b, c) {
            return b === !1 ? _.removeAttr(a, c) : a.setAttribute(c, c), c
        }
    }, _.each(_.expr.match.bool.source.match(/\w+/g), function(a, b) {
        var c = fb[b] || _.find.attr;
        fb[b] = function(a, b, d) {
            var e, f;
            return d || (f = fb[b], fb[b] = e, e = null != c(a, b, d) ? b.toLowerCase() : null, fb[b] = f), e
        }
    });
    var gb = /^(?:input|select|textarea|button)$/i;
    _.fn.extend({
        prop: function(a, b) {
            return qa(this, _.prop, a, b, arguments.length > 1)
        },
        removeProp: function(a) {
            return this.each(function() {
                delete this[_.propFix[a] || a]
            })
        }
    }), _.extend({
        propFix: {
            "for": "htmlFor",
            "class": "className"
        },
        prop: function(a, b, c) {
            var d, e, f, g = a.nodeType;
            return a && 3 !== g && 8 !== g && 2 !== g ? (f = 1 !== g || !_.isXMLDoc(a), f && (b = _.propFix[b] || b, e = _.propHooks[b]), void 0 !== c ? e && "set" in e && void 0 !== (d = e.set(a, c, b)) ? d : a[b] = c : e && "get" in e && null !== (d = e.get(a, b)) ? d : a[b]) : void 0
        },
        propHooks: {
            tabIndex: {
                get: function(a) {
                    return a.hasAttribute("tabindex") || gb.test(a.nodeName) || a.href ? a.tabIndex : -1
                }
            }
        }
    }), Y.optSelected || (_.propHooks.selected = {
        get: function(a) {
            var b = a.parentNode;
            return b && b.parentNode && b.parentNode.selectedIndex, null
        }
    }), _.each(["tabIndex", "readOnly", "maxLength", "cellSpacing", "cellPadding", "rowSpan", "colSpan", "useMap", "frameBorder", "contentEditable"], function() {
        _.propFix[this.toLowerCase()] = this
    });
    var hb = /[\t\r\n\f]/g;
    _.fn.extend({
        addClass: function(a) {
            var b, c, d, e, f, g, h = "string" == typeof a && a,
                i = 0,
                j = this.length;
            if (_.isFunction(a)) return this.each(function(b) {
                _(this).addClass(a.call(this, b, this.className))
            });
            if (h)
                for (b = (a || "").match(na) || []; j > i; i++)
                    if (c = this[i], d = 1 === c.nodeType && (c.className ? (" " + c.className + " ").replace(hb, " ") : " ")) {
                        for (f = 0; e = b[f++];) d.indexOf(" " + e + " ") < 0 && (d += e + " ");
                        g = _.trim(d), c.className !== g && (c.className = g)
                    }
            return this
        },
        removeClass: function(a) {
            var b, c, d, e, f, g, h = 0 === arguments.length || "string" == typeof a && a,
                i = 0,
                j = this.length;
            if (_.isFunction(a)) return this.each(function(b) {
                _(this).removeClass(a.call(this, b, this.className))
            });
            if (h)
                for (b = (a || "").match(na) || []; j > i; i++)
                    if (c = this[i], d = 1 === c.nodeType && (c.className ? (" " + c.className + " ").replace(hb, " ") : "")) {
                        for (f = 0; e = b[f++];)
                            for (; d.indexOf(" " + e + " ") >= 0;) d = d.replace(" " + e + " ", " ");
                        g = a ? _.trim(d) : "", c.className !== g && (c.className = g)
                    }
            return this
        },
        toggleClass: function(a, b) {
            var c = typeof a;
            return "boolean" == typeof b && "string" === c ? b ? this.addClass(a) : this.removeClass(a) : this.each(_.isFunction(a) ? function(c) {
                _(this).toggleClass(a.call(this, c, this.className, b), b)
            } : function() {
                if ("string" === c)
                    for (var b, d = 0, e = _(this), f = a.match(na) || []; b = f[d++];) e.hasClass(b) ? e.removeClass(b) : e.addClass(b);
                else(c === za || "boolean" === c) && (this.className && ra.set(this, "__className__", this.className), this.className = this.className || a === !1 ? "" : ra.get(this, "__className__") || "")
            })
        },
        hasClass: function(a) {
            for (var b = " " + a + " ", c = 0, d = this.length; d > c; c++)
                if (1 === this[c].nodeType && (" " + this[c].className + " ").replace(hb, " ").indexOf(b) >= 0) return !0;
            return !1
        }
    });
    var ib = /\r/g;
    _.fn.extend({
        val: function(a) {
            var b, c, d, e = this[0];
            return arguments.length ? (d = _.isFunction(a), this.each(function(c) {
                var e;
                1 === this.nodeType && (e = d ? a.call(this, c, _(this).val()) : a, null == e ? e = "" : "number" == typeof e ? e += "" : _.isArray(e) && (e = _.map(e, function(a) {
                    return null == a ? "" : a + ""
                })), b = _.valHooks[this.type] || _.valHooks[this.nodeName.toLowerCase()], b && "set" in b && void 0 !== b.set(this, e, "value") || (this.value = e))
            })) : e ? (b = _.valHooks[e.type] || _.valHooks[e.nodeName.toLowerCase()], b && "get" in b && void 0 !== (c = b.get(e, "value")) ? c : (c = e.value, "string" == typeof c ? c.replace(ib, "") : null == c ? "" : c)) : void 0
        }
    }), _.extend({
        valHooks: {
            option: {
                get: function(a) {
                    var b = _.find.attr(a, "value");
                    return null != b ? b : _.trim(_.text(a))
                }
            },
            select: {
                get: function(a) {
                    for (var b, c, d = a.options, e = a.selectedIndex, f = "select-one" === a.type || 0 > e, g = f ? null : [], h = f ? e + 1 : d.length, i = 0 > e ? h : f ? e : 0; h > i; i++)
                        if (c = d[i], !(!c.selected && i !== e || (Y.optDisabled ? c.disabled : null !== c.getAttribute("disabled")) || c.parentNode.disabled && _.nodeName(c.parentNode, "optgroup"))) {
                            if (b = _(c).val(), f) return b;
                            g.push(b)
                        }
                    return g
                },
                set: function(a, b) {
                    for (var c, d, e = a.options, f = _.makeArray(b), g = e.length; g--;) d = e[g], (d.selected = _.inArray(d.value, f) >= 0) && (c = !0);
                    return c || (a.selectedIndex = -1), f
                }
            }
        }
    }), _.each(["radio", "checkbox"], function() {
        _.valHooks[this] = {
            set: function(a, b) {
                return _.isArray(b) ? a.checked = _.inArray(_(a).val(), b) >= 0 : void 0
            }
        }, Y.checkOn || (_.valHooks[this].get = function(a) {
            return null === a.getAttribute("value") ? "on" : a.value
        })
    }), _.each("blur focus focusin focusout load resize scroll unload click dblclick mousedown mouseup mousemove mouseover mouseout mouseenter mouseleave change select submit keydown keypress keyup error contextmenu".split(" "), function(a, b) {
        _.fn[b] = function(a, c) {
            return arguments.length > 0 ? this.on(b, null, a, c) : this.trigger(b)
        }
    }), _.fn.extend({
        hover: function(a, b) {
            return this.mouseenter(a).mouseleave(b || a)
        },
        bind: function(a, b, c) {
            return this.on(a, null, b, c)
        },
        unbind: function(a, b) {
            return this.off(a, null, b)
        },
        delegate: function(a, b, c, d) {
            return this.on(b, a, c, d)
        },
        undelegate: function(a, b, c) {
            return 1 === arguments.length ? this.off(a, "**") : this.off(b, a || "**", c)
        }
    });
    var jb = _.now(),
        kb = /\?/;
    _.parseJSON = function(a) {
        return JSON.parse(a + "")
    }, _.parseXML = function(a) {
        var b, c;
        if (!a || "string" != typeof a) return null;
        try {
            c = new DOMParser, b = c.parseFromString(a, "text/xml")
        } catch (d) {
            b = void 0
        }
        return (!b || b.getElementsByTagName("parsererror").length) && _.error("Invalid XML: " + a), b
    };
    var lb = /#.*$/,
        mb = /([?&])_=[^&]*/,
        nb = /^(.*?):[ \t]*([^\r\n]*)$/gm,
        ob = /^(?:about|app|app-storage|.+-extension|file|res|widget):$/,
        pb = /^(?:GET|HEAD)$/,
        qb = /^\/\//,
        rb = /^([\w.+-]+:)(?:\/\/(?:[^\/?#]*@|)([^\/?#:]*)(?::(\d+)|)|)/,
        sb = {},
        tb = {},
        ub = "*/".concat("*"),
        vb = a.location.href,
        wb = rb.exec(vb.toLowerCase()) || [];
    _.extend({
        active: 0,
        lastModified: {},
        etag: {},
        ajaxSettings: {
            url: vb,
            type: "GET",
            isLocal: ob.test(wb[1]),
            global: !0,
            processData: !0,
            async: !0,
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            accepts: {
                "*": ub,
                text: "text/plain",
                html: "text/html",
                xml: "application/xml, text/xml",
                json: "application/json, text/javascript"
            },
            contents: {
                xml: /xml/,
                html: /html/,
                json: /json/
            },
            responseFields: {
                xml: "responseXML",
                text: "responseText",
                json: "responseJSON"
            },
            converters: {
                "* text": String,
                "text html": !0,
                "text json": _.parseJSON,
                "text xml": _.parseXML
            },
            flatOptions: {
                url: !0,
                context: !0
            }
        },
        ajaxSetup: function(a, b) {
            return b ? L(L(a, _.ajaxSettings), b) : L(_.ajaxSettings, a)
        },
        ajaxPrefilter: J(sb),
        ajaxTransport: J(tb),
        ajax: function(a, b) {
            function c(a, b, c, g) {
                var i, k, r, s, u, w = b;
                2 !== t && (t = 2, h && clearTimeout(h), d = void 0, f = g || "", v.readyState = a > 0 ? 4 : 0, i = a >= 200 && 300 > a || 304 === a, c && (s = M(l, v, c)), s = N(l, s, v, i), i ? (l.ifModified && (u = v.getResponseHeader("Last-Modified"), u && (_.lastModified[e] = u), u = v.getResponseHeader("etag"), u && (_.etag[e] = u)), 204 === a || "HEAD" === l.type ? w = "nocontent" : 304 === a ? w = "notmodified" : (w = s.state, k = s.data, r = s.error, i = !r)) : (r = w, (a || !w) && (w = "error", 0 > a && (a = 0))), v.status = a, v.statusText = (b || w) + "", i ? o.resolveWith(m, [k, w, v]) : o.rejectWith(m, [v, w, r]), v.statusCode(q), q = void 0, j && n.trigger(i ? "ajaxSuccess" : "ajaxError", [v, l, i ? k : r]), p.fireWith(m, [v, w]), j && (n.trigger("ajaxComplete", [v, l]), --_.active || _.event.trigger("ajaxStop")))
            }
            "object" == typeof a && (b = a, a = void 0), b = b || {};
            var d, e, f, g, h, i, j, k, l = _.ajaxSetup({}, b),
                m = l.context || l,
                n = l.context && (m.nodeType || m.jquery) ? _(m) : _.event,
                o = _.Deferred(),
                p = _.Callbacks("once memory"),
                q = l.statusCode || {},
                r = {},
                s = {},
                t = 0,
                u = "canceled",
                v = {
                    readyState: 0,
                    getResponseHeader: function(a) {
                        var b;
                        if (2 === t) {
                            if (!g)
                                for (g = {}; b = nb.exec(f);) g[b[1].toLowerCase()] = b[2];
                            b = g[a.toLowerCase()]
                        }
                        return null == b ? null : b
                    },
                    getAllResponseHeaders: function() {
                        return 2 === t ? f : null
                    },
                    setRequestHeader: function(a, b) {
                        var c = a.toLowerCase();
                        return t || (a = s[c] = s[c] || a, r[a] = b), this
                    },
                    overrideMimeType: function(a) {
                        return t || (l.mimeType = a), this
                    },
                    statusCode: function(a) {
                        var b;
                        if (a)
                            if (2 > t)
                                for (b in a) q[b] = [q[b], a[b]];
                            else v.always(a[v.status]);
                        return this
                    },
                    abort: function(a) {
                        var b = a || u;
                        return d && d.abort(b), c(0, b), this
                    }
                };
            if (o.promise(v).complete = p.add, v.success = v.done, v.error = v.fail, l.url = ((a || l.url || vb) + "").replace(lb, "").replace(qb, wb[1] + "//"), l.type = b.method || b.type || l.method || l.type, l.dataTypes = _.trim(l.dataType || "*").toLowerCase().match(na) || [""], null == l.crossDomain && (i = rb.exec(l.url.toLowerCase()), l.crossDomain = !(!i || i[1] === wb[1] && i[2] === wb[2] && (i[3] || ("http:" === i[1] ? "80" : "443")) === (wb[3] || ("http:" === wb[1] ? "80" : "443")))), l.data && l.processData && "string" != typeof l.data && (l.data = _.param(l.data, l.traditional)), K(sb, l, b, v), 2 === t) return v;
            j = _.event && l.global, j && 0 === _.active++ && _.event.trigger("ajaxStart"), l.type = l.type.toUpperCase(), l.hasContent = !pb.test(l.type), e = l.url, l.hasContent || (l.data && (e = l.url += (kb.test(e) ? "&" : "?") + l.data, delete l.data), l.cache === !1 && (l.url = mb.test(e) ? e.replace(mb, "$1_=" + jb++) : e + (kb.test(e) ? "&" : "?") + "_=" + jb++)), l.ifModified && (_.lastModified[e] && v.setRequestHeader("If-Modified-Since", _.lastModified[e]), _.etag[e] && v.setRequestHeader("If-None-Match", _.etag[e])), (l.data && l.hasContent && l.contentType !== !1 || b.contentType) && v.setRequestHeader("Content-Type", l.contentType), v.setRequestHeader("Accept", l.dataTypes[0] && l.accepts[l.dataTypes[0]] ? l.accepts[l.dataTypes[0]] + ("*" !== l.dataTypes[0] ? ", " + ub + "; q=0.01" : "") : l.accepts["*"]);
            for (k in l.headers) v.setRequestHeader(k, l.headers[k]);
            if (l.beforeSend && (l.beforeSend.call(m, v, l) === !1 || 2 === t)) return v.abort();
            u = "abort";
            for (k in {
                    success: 1,
                    error: 1,
                    complete: 1
                }) v[k](l[k]);
            if (d = K(tb, l, b, v)) {
                v.readyState = 1, j && n.trigger("ajaxSend", [v, l]), l.async && l.timeout > 0 && (h = setTimeout(function() {
                    v.abort("timeout")
                }, l.timeout));
                try {
                    t = 1, d.send(r, c)
                } catch (w) {
                    if (!(2 > t)) throw w;
                    c(-1, w)
                }
            } else c(-1, "No Transport");
            return v
        },
        getJSON: function(a, b, c) {
            return _.get(a, b, c, "json")
        },
        getScript: function(a, b) {
            return _.get(a, void 0, b, "script")
        }
    }), _.each(["get", "post"], function(a, b) {
        _[b] = function(a, c, d, e) {
            return _.isFunction(c) && (e = e || d, d = c, c = void 0), _.ajax({
                url: a,
                type: b,
                dataType: e,
                data: c,
                success: d
            })
        }
    }), _._evalUrl = function(a) {
        return _.ajax({
            url: a,
            type: "GET",
            dataType: "script",
            async: !1,
            global: !1,
            "throws": !0
        })
    }, _.fn.extend({
        wrapAll: function(a) {
            var b;
            return _.isFunction(a) ? this.each(function(b) {
                _(this).wrapAll(a.call(this, b))
            }) : (this[0] && (b = _(a, this[0].ownerDocument).eq(0).clone(!0), this[0].parentNode && b.insertBefore(this[0]), b.map(function() {
                for (var a = this; a.firstElementChild;) a = a.firstElementChild;
                return a
            }).append(this)), this)
        },
        wrapInner: function(a) {
            return this.each(_.isFunction(a) ? function(b) {
                _(this).wrapInner(a.call(this, b))
            } : function() {
                var b = _(this),
                    c = b.contents();
                c.length ? c.wrapAll(a) : b.append(a)
            })
        },
        wrap: function(a) {
            var b = _.isFunction(a);
            return this.each(function(c) {
                _(this).wrapAll(b ? a.call(this, c) : a)
            })
        },
        unwrap: function() {
            return this.parent().each(function() {
                _.nodeName(this, "body") || _(this).replaceWith(this.childNodes)
            }).end()
        }
    }), _.expr.filters.hidden = function(a) {
        return a.offsetWidth <= 0 && a.offsetHeight <= 0
    }, _.expr.filters.visible = function(a) {
        return !_.expr.filters.hidden(a)
    };
    var xb = /%20/g,
        yb = /\[\]$/,
        zb = /\r?\n/g,
        Ab = /^(?:submit|button|image|reset|file)$/i,
        Bb = /^(?:input|select|textarea|keygen)/i;
    _.param = function(a, b) {
        var c, d = [],
            e = function(a, b) {
                b = _.isFunction(b) ? b() : null == b ? "" : b, d[d.length] = encodeURIComponent(a) + "=" + encodeURIComponent(b)
            };
        if (void 0 === b && (b = _.ajaxSettings && _.ajaxSettings.traditional), _.isArray(a) || a.jquery && !_.isPlainObject(a)) _.each(a, function() {
            e(this.name, this.value)
        });
        else
            for (c in a) O(c, a[c], b, e);
        return d.join("&").replace(xb, "+")
    }, _.fn.extend({
        serialize: function() {
            return _.param(this.serializeArray())
        },
        serializeArray: function() {
            return this.map(function() {
                var a = _.prop(this, "elements");
                return a ? _.makeArray(a) : this
            }).filter(function() {
                var a = this.type;
                return this.name && !_(this).is(":disabled") && Bb.test(this.nodeName) && !Ab.test(a) && (this.checked || !ya.test(a))
            }).map(function(a, b) {
                var c = _(this).val();
                return null == c ? null : _.isArray(c) ? _.map(c, function(a) {
                    return {
                        name: b.name,
                        value: a.replace(zb, "\r\n")
                    }
                }) : {
                    name: b.name,
                    value: c.replace(zb, "\r\n")
                }
            }).get()
        }
    }), _.ajaxSettings.xhr = function() {
        try {
            return new XMLHttpRequest
        } catch (a) {}
    };
    var Cb = 0,
        Db = {},
        Eb = {
            0: 200,
            1223: 204
        },
        Fb = _.ajaxSettings.xhr();
    a.attachEvent && a.attachEvent("onunload", function() {
        for (var a in Db) Db[a]()
    }), Y.cors = !!Fb && "withCredentials" in Fb, Y.ajax = Fb = !!Fb, _.ajaxTransport(function(a) {
        var b;
        return Y.cors || Fb && !a.crossDomain ? {
            send: function(c, d) {
                var e, f = a.xhr(),
                    g = ++Cb;
                if (f.open(a.type, a.url, a.async, a.username, a.password), a.xhrFields)
                    for (e in a.xhrFields) f[e] = a.xhrFields[e];
                a.mimeType && f.overrideMimeType && f.overrideMimeType(a.mimeType), a.crossDomain || c["X-Requested-With"] || (c["X-Requested-With"] = "XMLHttpRequest");
                for (e in c) f.setRequestHeader(e, c[e]);
                b = function(a) {
                    return function() {
                        b && (delete Db[g], b = f.onload = f.onerror = null, "abort" === a ? f.abort() : "error" === a ? d(f.status, f.statusText) : d(Eb[f.status] || f.status, f.statusText, "string" == typeof f.responseText ? {
                            text: f.responseText
                        } : void 0, f.getAllResponseHeaders()))
                    }
                }, f.onload = b(), f.onerror = b("error"), b = Db[g] = b("abort");
                try {
                    f.send(a.hasContent && a.data || null)
                } catch (h) {
                    if (b) throw h
                }
            },
            abort: function() {
                b && b()
            }
        } : void 0
    }), _.ajaxSetup({
        accepts: {
            script: "text/javascript, application/javascript, application/ecmascript, application/x-ecmascript"
        },
        contents: {
            script: /(?:java|ecma)script/
        },
        converters: {
            "text script": function(a) {
                return _.globalEval(a), a
            }
        }
    }), _.ajaxPrefilter("script", function(a) {
        void 0 === a.cache && (a.cache = !1), a.crossDomain && (a.type = "GET")
    }), _.ajaxTransport("script", function(a) {
        if (a.crossDomain) {
            var b, c;
            return {
                send: function(d, e) {
                    b = _("<script>").prop({
                        async: !0,
                        charset: a.scriptCharset,
                        src: a.url
                    }).on("load error", c = function(a) {
                        b.remove(), c = null, a && e("error" === a.type ? 404 : 200, a.type)
                    }), Z.head.appendChild(b[0])
                },
                abort: function() {
                    c && c()
                }
            }
        }
    });
    var Gb = [],
        Hb = /(=)\?(?=&|$)|\?\?/;
    _.ajaxSetup({
        jsonp: "callback",
        jsonpCallback: function() {
            var a = Gb.pop() || _.expando + "_" + jb++;
            return this[a] = !0, a
        }
    }), _.ajaxPrefilter("json jsonp", function(b, c, d) {
        var e, f, g, h = b.jsonp !== !1 && (Hb.test(b.url) ? "url" : "string" == typeof b.data && !(b.contentType || "").indexOf("application/x-www-form-urlencoded") && Hb.test(b.data) && "data");
        return h || "jsonp" === b.dataTypes[0] ? (e = b.jsonpCallback = _.isFunction(b.jsonpCallback) ? b.jsonpCallback() : b.jsonpCallback, h ? b[h] = b[h].replace(Hb, "$1" + e) : b.jsonp !== !1 && (b.url += (kb.test(b.url) ? "&" : "?") + b.jsonp + "=" + e), b.converters["script json"] = function() {
            return g || _.error(e + " was not called"), g[0]
        }, b.dataTypes[0] = "json", f = a[e], a[e] = function() {
            g = arguments
        }, d.always(function() {
            a[e] = f, b[e] && (b.jsonpCallback = c.jsonpCallback, Gb.push(e)), g && _.isFunction(f) && f(g[0]), g = f = void 0
        }), "script") : void 0
    }), _.parseHTML = function(a, b, c) {
        if (!a || "string" != typeof a) return null;
        "boolean" == typeof b && (c = b, b = !1), b = b || Z;
        var d = ga.exec(a),
            e = !c && [];
        return d ? [b.createElement(d[1])] : (d = _.buildFragment([a], b, e), e && e.length && _(e).remove(), _.merge([], d.childNodes))
    };
    var Ib = _.fn.load;
    _.fn.load = function(a, b, c) {
        if ("string" != typeof a && Ib) return Ib.apply(this, arguments);
        var d, e, f, g = this,
            h = a.indexOf(" ");
        return h >= 0 && (d = _.trim(a.slice(h)), a = a.slice(0, h)), _.isFunction(b) ? (c = b, b = void 0) : b && "object" == typeof b && (e = "POST"), g.length > 0 && _.ajax({
            url: a,
            type: e,
            dataType: "html",
            data: b
        }).done(function(a) {
            f = arguments, g.html(d ? _("<div>").append(_.parseHTML(a)).find(d) : a)
        }).complete(c && function(a, b) {
            g.each(c, f || [a.responseText, b, a])
        }), this
    }, _.each(["ajaxStart", "ajaxStop", "ajaxComplete", "ajaxError", "ajaxSuccess", "ajaxSend"], function(a, b) {
        _.fn[b] = function(a) {
            return this.on(b, a)
        }
    }), _.expr.filters.animated = function(a) {
        return _.grep(_.timers, function(b) {
            return a === b.elem
        }).length
    };
    var Jb = a.document.documentElement;
    _.offset = {
        setOffset: function(a, b, c) {
            var d, e, f, g, h, i, j, k = _.css(a, "position"),
                l = _(a),
                m = {};
            "static" === k && (a.style.position = "relative"), h = l.offset(), f = _.css(a, "top"), i = _.css(a, "left"), j = ("absolute" === k || "fixed" === k) && (f + i).indexOf("auto") > -1, j ? (d = l.position(), g = d.top, e = d.left) : (g = parseFloat(f) || 0, e = parseFloat(i) || 0), _.isFunction(b) && (b = b.call(a, c, h)), null != b.top && (m.top = b.top - h.top + g), null != b.left && (m.left = b.left - h.left + e), "using" in b ? b.using.call(a, m) : l.css(m)
        }
    }, _.fn.extend({
        offset: function(a) {
            if (arguments.length) return void 0 === a ? this : this.each(function(b) {
                _.offset.setOffset(this, a, b)
            });
            var b, c, d = this[0],
                e = {
                    top: 0,
                    left: 0
                },
                f = d && d.ownerDocument;
            return f ? (b = f.documentElement, _.contains(b, d) ? (typeof d.getBoundingClientRect !== za && (e = d.getBoundingClientRect()), c = P(f), {
                top: e.top + c.pageYOffset - b.clientTop,
                left: e.left + c.pageXOffset - b.clientLeft
            }) : e) : void 0
        },
        position: function() {
            if (this[0]) {
                var a, b, c = this[0],
                    d = {
                        top: 0,
                        left: 0
                    };
                return "fixed" === _.css(c, "position") ? b = c.getBoundingClientRect() : (a = this.offsetParent(), b = this.offset(), _.nodeName(a[0], "html") || (d = a.offset()), d.top += _.css(a[0], "borderTopWidth", !0), d.left += _.css(a[0], "borderLeftWidth", !0)), {
                    top: b.top - d.top - _.css(c, "marginTop", !0),
                    left: b.left - d.left - _.css(c, "marginLeft", !0)
                }
            }
        },
        offsetParent: function() {
            return this.map(function() {
                for (var a = this.offsetParent || Jb; a && !_.nodeName(a, "html") && "static" === _.css(a, "position");) a = a.offsetParent;
                return a || Jb
            })
        }
    }), _.each({
        scrollLeft: "pageXOffset",
        scrollTop: "pageYOffset"
    }, function(b, c) {
        var d = "pageYOffset" === c;
        _.fn[b] = function(e) {
            return qa(this, function(b, e, f) {
                var g = P(b);
                return void 0 === f ? g ? g[c] : b[e] : void(g ? g.scrollTo(d ? a.pageXOffset : f, d ? f : a.pageYOffset) : b[e] = f)
            }, b, e, arguments.length, null)
        }
    }), _.each(["top", "left"], function(a, b) {
        _.cssHooks[b] = w(Y.pixelPosition, function(a, c) {
            return c ? (c = v(a, b), Qa.test(c) ? _(a).position()[b] + "px" : c) : void 0
        })
    }), _.each({
        Height: "height",
        Width: "width"
    }, function(a, b) {
        _.each({
            padding: "inner" + a,
            content: b,
            "": "outer" + a
        }, function(c, d) {
            _.fn[d] = function(d, e) {
                var f = arguments.length && (c || "boolean" != typeof d),
                    g = c || (d === !0 || e === !0 ? "margin" : "border");
                return qa(this, function(b, c, d) {
                    var e;
                    return _.isWindow(b) ? b.document.documentElement["client" + a] : 9 === b.nodeType ? (e = b.documentElement, Math.max(b.body["scroll" + a], e["scroll" + a], b.body["offset" + a], e["offset" + a], e["client" + a])) : void 0 === d ? _.css(b, c, g) : _.style(b, c, d, g)
                }, b, f ? d : void 0, f, null)
            }
        })
    }), _.fn.size = function() {
        return this.length
    }, _.fn.andSelf = _.fn.addBack, "function" == typeof define && define.amd && define("jquery", [], function() {
        return _
    });
    var Kb = a.jQuery,
        Lb = a.$;
    return _.noConflict = function(b) {
        return a.$ === _ && (a.$ = Lb), b && a.jQuery === _ && (a.jQuery = Kb), _
    }, typeof b === za && (a.jQuery = a.$ = _), _
}),
function() {
    function a(a, b) {
        if (a !== b) {
            var c = null === a,
                d = a === u,
                e = a === a,
                f = null === b,
                g = b === u,
                h = b === b;
            if (a > b && !f || !e || c && !g && h || d && h) return 1;
            if (b > a && !c || !h || f && !d && e || g && e) return -1
        }
        return 0
    }

    function b(a, b, c) {
        for (var d = a.length, e = c ? d : -1; c ? e-- : ++e < d;)
            if (b(a[e], e, a)) return e;
        return -1
    }

    function c(a, b, c) {
        if (b !== b) return m(a, c);
        c -= 1;
        for (var d = a.length; ++c < d;)
            if (a[c] === b) return c;
        return -1
    }

    function d(a) {
        return "function" == typeof a || !1
    }

    function e(a) {
        return null == a ? "" : a + ""
    }

    function f(a, b) {
        for (var c = -1, d = a.length; ++c < d && -1 < b.indexOf(a.charAt(c)););
        return c
    }

    function g(a, b) {
        for (var c = a.length; c-- && -1 < b.indexOf(a.charAt(c)););
        return c
    }

    function h(b, c) {
        return a(b.a, c.a) || b.b - c.b
    }

    function i(a) {
        return Ja[a]
    }

    function j(a) {
        return Ka[a]
    }

    function k(a, b, c) {
        return b ? a = Na[a] : c && (a = Oa[a]), "\\" + a
    }

    function l(a) {
        return "\\" + Oa[a]
    }

    function m(a, b, c) {
        var d = a.length;
        for (b += c ? 0 : -1; c ? b-- : ++b < d;) {
            var e = a[b];
            if (e !== e) return b
        }
        return -1
    }

    function n(a) {
        return !!a && "object" == typeof a
    }

    function o(a) {
        return 160 >= a && a >= 9 && 13 >= a || 32 == a || 160 == a || 5760 == a || 6158 == a || a >= 8192 && (8202 >= a || 8232 == a || 8233 == a || 8239 == a || 8287 == a || 12288 == a || 65279 == a)
    }

    function p(a, b) {
        for (var c = -1, d = a.length, e = -1, f = []; ++c < d;) a[c] === b && (a[c] = N, f[++e] = c);
        return f
    }

    function q(a) {
        for (var b = -1, c = a.length; ++b < c && o(a.charCodeAt(b)););
        return b
    }

    function r(a) {
        for (var b = a.length; b-- && o(a.charCodeAt(b)););
        return b
    }

    function s(a) {
        return La[a]
    }

    function t(o) {
        function Ja(a) {
            if (n(a) && !(Bf(a) || a instanceof Ma)) {
                if (a instanceof La) return a;
                if (_d.call(a, "__chain__") && _d.call(a, "__wrapped__")) return Pc(a)
            }
            return new La(a)
        }

        function Ka() {}

        function La(a, b, c) {
            this.__wrapped__ = a, this.__actions__ = c || [], this.__chain__ = !!b
        }

        function Ma(a) {
            this.__wrapped__ = a, this.__actions__ = [], this.__dir__ = 1, this.__filtered__ = !1, this.__iteratees__ = [], this.__takeCount__ = Ae, this.__views__ = []
        }

        function Na() {
            this.__data__ = {}
        }

        function Oa(a) {
            var b = a ? a.length : 0;
            for (this.data = {
                    hash: pe(null),
                    set: new je
                }; b--;) this.push(a[b])
        }

        function Pa(a, b) {
            var c = a.data;
            return ("string" == typeof b || pd(b) ? c.set.has(b) : c.hash[b]) ? 0 : -1
        }

        function Qa(a, b) {
            var c = -1,
                d = a.length;
            for (b || (b = Nd(d)); ++c < d;) b[c] = a[c];
            return b
        }

        function Ra(a, b) {
            for (var c = -1, d = a.length; ++c < d && !1 !== b(a[c], c, a););
            return a
        }

        function Sa(a, b) {
            for (var c = -1, d = a.length; ++c < d;)
                if (!b(a[c], c, a)) return !1;
            return !0
        }

        function Ta(a, b) {
            for (var c = -1, d = a.length, e = -1, f = []; ++c < d;) {
                var g = a[c];
                b(g, c, a) && (f[++e] = g)
            }
            return f
        }

        function Wa(a, b) {
            for (var c = -1, d = a.length, e = Nd(d); ++c < d;) e[c] = b(a[c], c, a);
            return e
        }

        function Xa(a, b) {
            for (var c = -1, d = b.length, e = a.length; ++c < d;) a[e + c] = b[c];
            return a
        }

        function Ya(a, b, c, d) {
            var e = -1,
                f = a.length;
            for (d && f && (c = a[++e]); ++e < f;) c = b(c, a[e], e, a);
            return c
        }

        function Za(a, b) {
            for (var c = -1, d = a.length; ++c < d;)
                if (b(a[c], c, a)) return !0;
            return !1
        }

        function $a(a, b, c, d) {
            return a !== u && _d.call(d, c) ? a : b
        }

        function _a(a, b, c) {
            for (var d = -1, e = Mf(b), f = e.length; ++d < f;) {
                var g = e[d],
                    h = a[g],
                    i = c(h, b[g], g, a, b);
                (i === i ? i === h : h !== h) && (h !== u || g in a) || (a[g] = i)
            }
            return a
        }

        function ab(a, b) {
            return null == b ? a : cb(b, Mf(b), a)
        }

        function bb(a, b) {
            for (var c = -1, d = null == a, e = !d && Cc(a), f = e ? a.length : 0, g = b.length, h = Nd(g); ++c < g;) {
                var i = b[c];
                h[c] = e ? Dc(i, f) ? a[i] : u : d ? u : a[i]
            }
            return h
        }

        function cb(a, b, c) {
            c || (c = {});
            for (var d = -1, e = b.length; ++d < e;) {
                var f = b[d];
                c[f] = a[f]
            }
            return c
        }

        function db(a, b, c) {
            var d = typeof a;
            return "function" == d ? b === u ? a : Nb(a, b, c) : null == a ? Id : "object" == d ? ub(a) : b === u ? Md(a) : vb(a, b)
        }

        function eb(a, b, c, d, e, f, g) {
            var h;
            if (c && (h = e ? c(a, d, e) : c(a)), h !== u) return h;
            if (!pd(a)) return a;
            if (d = Bf(a)) {
                if (h = yc(a), !b) return Qa(a, h)
            } else {
                var i = be.call(a),
                    j = i == T;
                if (i != V && i != O && (!j || e)) return Ia[i] ? Ac(a, i, b) : e ? a : {};
                if (h = zc(j ? {} : a), !b) return ab(h, a)
            }
            for (f || (f = []), g || (g = []), e = f.length; e--;)
                if (f[e] == a) return g[e];
            return f.push(a), g.push(h), (d ? Ra : nb)(a, function(d, e) {
                h[e] = eb(d, b, c, e, a, f, g)
            }), h
        }

        function fb(a, b, c) {
            if ("function" != typeof a) throw new Wd(M);
            return ke(function() {
                a.apply(u, c)
            }, b)
        }

        function gb(a, b) {
            var d = a ? a.length : 0,
                e = [];
            if (!d) return e;
            var f = -1,
                g = vc(),
                h = g === c,
                i = h && b.length >= J && pe && je ? new Oa(b) : null,
                j = b.length;
            i && (g = Pa, h = !1, b = i);
            a: for (; ++f < d;)
                if (i = a[f], h && i === i) {
                    for (var k = j; k--;)
                        if (b[k] === i) continue a;
                    e.push(i)
                } else 0 > g(b, i, 0) && e.push(i);
            return e
        }

        function hb(a, b) {
            var c = !0;
            return He(a, function(a, d, e) {
                return c = !!b(a, d, e)
            }), c
        }

        function ib(a, b, c, d) {
            var e = d,
                f = e;
            return He(a, function(a, g, h) {
                g = +b(a, g, h), (c(g, e) || g === d && g === f) && (e = g, f = a)
            }), f
        }

        function jb(a, b) {
            var c = [];
            return He(a, function(a, d, e) {
                b(a, d, e) && c.push(a)
            }), c
        }

        function kb(a, b, c, d) {
            var e;
            return c(a, function(a, c, f) {
                return b(a, c, f) ? (e = d ? c : a, !1) : void 0
            }), e
        }

        function lb(a, b, c, d) {
            d || (d = []);
            for (var e = -1, f = a.length; ++e < f;) {
                var g = a[e];
                n(g) && Cc(g) && (c || Bf(g) || ld(g)) ? b ? lb(g, b, c, d) : Xa(d, g) : c || (d[d.length] = g)
            }
            return d
        }

        function mb(a, b) {
            Je(a, b, Ad)
        }

        function nb(a, b) {
            return Je(a, b, Mf)
        }

        function ob(a, b) {
            return Ke(a, b, Mf)
        }

        function pb(a, b) {
            for (var c = -1, d = b.length, e = -1, f = []; ++c < d;) {
                var g = b[c];
                od(a[g]) && (f[++e] = g)
            }
            return f
        }

        function qb(a, b, c) {
            if (null != a) {
                c !== u && c in Nc(a) && (b = [c]), c = 0;
                for (var d = b.length; null != a && d > c;) a = a[b[c++]];
                return c && c == d ? a : u
            }
        }

        function rb(a, b, c, d, e, f) {
            if (a === b) a = !0;
            else if (null == a || null == b || !pd(a) && !n(b)) a = a !== a && b !== b;
            else a: {
                var g = rb,
                    h = Bf(a),
                    i = Bf(b),
                    j = P,
                    k = P;
                h || (j = be.call(a), j == O ? j = V : j != V && (h = vd(a))), i || (k = be.call(b), k == O ? k = V : k != V && vd(b));
                var l = j == V,
                    i = k == V,
                    k = j == k;
                if (!k || h || l) {
                    if (!d && (j = l && _d.call(a, "__wrapped__"), i = i && _d.call(b, "__wrapped__"), j || i)) {
                        a = g(j ? a.value() : a, i ? b.value() : b, c, d, e, f);
                        break a
                    }
                    if (k) {
                        for (e || (e = []), f || (f = []), j = e.length; j--;)
                            if (e[j] == a) {
                                a = f[j] == b;
                                break a
                            }
                        e.push(a), f.push(b), a = (h ? qc : sc)(a, b, g, c, d, e, f), e.pop(), f.pop()
                    } else a = !1
                } else a = rc(a, b, j)
            }
            return a
        }

        function sb(a, b, c) {
            var d = b.length,
                e = d,
                f = !c;
            if (null == a) return !e;
            for (a = Nc(a); d--;) {
                var g = b[d];
                if (f && g[2] ? g[1] !== a[g[0]] : !(g[0] in a)) return !1
            }
            for (; ++d < e;) {
                var g = b[d],
                    h = g[0],
                    i = a[h],
                    j = g[1];
                if (f && g[2]) {
                    if (i === u && !(h in a)) return !1
                } else if (g = c ? c(i, j, h) : u, g === u ? !rb(j, i, c, !0) : !g) return !1
            }
            return !0
        }

        function tb(a, b) {
            var c = -1,
                d = Cc(a) ? Nd(a.length) : [];
            return He(a, function(a, e, f) {
                d[++c] = b(a, e, f)
            }), d
        }

        function ub(a) {
            var b = wc(a);
            if (1 == b.length && b[0][2]) {
                var c = b[0][0],
                    d = b[0][1];
                return function(a) {
                    return null == a ? !1 : a[c] === d && (d !== u || c in Nc(a))
                }
            }
            return function(a) {
                return sb(a, b)
            }
        }

        function vb(a, b) {
            var c = Bf(a),
                d = Fc(a) && b === b && !pd(b),
                e = a + "";
            return a = Oc(a),
                function(f) {
                    if (null == f) return !1;
                    var g = e;
                    if (f = Nc(f), !(!c && d || g in f)) {
                        if (f = 1 == a.length ? f : qb(f, Cb(a, 0, -1)), null == f) return !1;
                        g = Uc(a), f = Nc(f)
                    }
                    return f[g] === b ? b !== u || g in f : rb(b, f[g], u, !0)
                }
        }

        function wb(a, b, c, d, e) {
            if (!pd(a)) return a;
            var f = Cc(b) && (Bf(b) || vd(b)),
                g = f ? u : Mf(b);
            return Ra(g || b, function(h, i) {
                if (g && (i = h, h = b[i]), n(h)) {
                    d || (d = []), e || (e = []);
                    a: {
                        for (var j = i, k = d, l = e, m = k.length, o = b[j]; m--;)
                            if (k[m] == o) {
                                a[j] = l[m];
                                break a
                            }
                        var m = a[j],
                            p = c ? c(m, o, j, a, b) : u,
                            q = p === u;
                        q && (p = o, Cc(o) && (Bf(o) || vd(o)) ? p = Bf(m) ? m : Cc(m) ? Qa(m) : [] : sd(o) || ld(o) ? p = ld(m) ? yd(m) : sd(m) ? m : {} : q = !1), k.push(o), l.push(p), q ? a[j] = wb(p, o, c, k, l) : (p === p ? p !== m : m === m) && (a[j] = p)
                    }
                } else j = a[i], k = c ? c(j, h, i, a, b) : u, (l = k === u) && (k = h), k === u && (!f || i in a) || !l && (k === k ? k === j : j !== j) || (a[i] = k)
            }), a
        }

        function xb(a) {
            return function(b) {
                return null == b ? u : b[a]
            }
        }

        function yb(a) {
            var b = a + "";
            return a = Oc(a),
                function(c) {
                    return qb(c, a, b)
                }
        }

        function zb(a, b) {
            for (var c = a ? b.length : 0; c--;) {
                var d = b[c];
                if (d != e && Dc(d)) {
                    var e = d;
                    le.call(a, d, 1)
                }
            }
        }

        function Ab(a, b) {
            return a + qe(ye() * (b - a + 1))
        }

        function Bb(a, b, c, d, e) {
            return e(a, function(a, e, f) {
                c = d ? (d = !1, a) : b(c, a, e, f)
            }), c
        }

        function Cb(a, b, c) {
            var d = -1,
                e = a.length;
            for (b = null == b ? 0 : +b || 0, 0 > b && (b = -b > e ? 0 : e + b), c = c === u || c > e ? e : +c || 0, 0 > c && (c += e), e = b > c ? 0 : c - b >>> 0, b >>>= 0, c = Nd(e); ++d < e;) c[d] = a[d + b];
            return c
        }

        function Db(a, b) {
            var c;
            return He(a, function(a, d, e) {
                return c = b(a, d, e), !c
            }), !!c
        }

        function Eb(a, b) {
            var c = a.length;
            for (a.sort(b); c--;) a[c] = a[c].c;
            return a
        }

        function Fb(b, c, d) {
            var e = tc(),
                f = -1;
            return c = Wa(c, function(a) {
                return e(a)
            }), b = tb(b, function(a) {
                return {
                    a: Wa(c, function(b) {
                        return b(a)
                    }),
                    b: ++f,
                    c: a
                }
            }), Eb(b, function(b, c) {
                var e;
                a: {
                    for (var f = -1, g = b.a, h = c.a, i = g.length, j = d.length; ++f < i;)
                        if (e = a(g[f], h[f])) {
                            if (f >= j) break a;
                            f = d[f], e *= "asc" === f || !0 === f ? 1 : -1;
                            break a
                        }
                    e = b.b - c.b
                }
                return e
            })
        }

        function Gb(a, b) {
            var c = 0;
            return He(a, function(a, d, e) {
                c += +b(a, d, e) || 0
            }), c
        }

        function Hb(a, b) {
            var d = -1,
                e = vc(),
                f = a.length,
                g = e === c,
                h = g && f >= J,
                i = h && pe && je ? new Oa(void 0) : null,
                j = [];
            i ? (e = Pa, g = !1) : (h = !1, i = b ? [] : j);
            a: for (; ++d < f;) {
                var k = a[d],
                    l = b ? b(k, d, a) : k;
                if (g && k === k) {
                    for (var m = i.length; m--;)
                        if (i[m] === l) continue a;
                    b && i.push(l), j.push(k)
                } else 0 > e(i, l, 0) && ((b || h) && i.push(l), j.push(k))
            }
            return j
        }

        function Ib(a, b) {
            for (var c = -1, d = b.length, e = Nd(d); ++c < d;) e[c] = a[b[c]];
            return e
        }

        function Jb(a, b, c, d) {
            for (var e = a.length, f = d ? e : -1;
                (d ? f-- : ++f < e) && b(a[f], f, a););
            return c ? Cb(a, d ? 0 : f, d ? f + 1 : e) : Cb(a, d ? f + 1 : 0, d ? e : f)
        }

        function Kb(a, b) {
            var c = a;
            c instanceof Ma && (c = c.value());
            for (var d = -1, e = b.length; ++d < e;) var f = b[d],
                c = f.func.apply(f.thisArg, Xa([c], f.args));
            return c
        }

        function Lb(a, b, c) {
            var d = 0,
                e = a ? a.length : d;
            if ("number" == typeof b && b === b && Ce >= e) {
                for (; e > d;) {
                    var f = d + e >>> 1,
                        g = a[f];
                    (c ? b >= g : b > g) && null !== g ? d = f + 1 : e = f
                }
                return e
            }
            return Mb(a, b, Id, c)
        }

        function Mb(a, b, c, d) {
            b = c(b);
            for (var e = 0, f = a ? a.length : 0, g = b !== b, h = null === b, i = b === u; f > e;) {
                var j = qe((e + f) / 2),
                    k = c(a[j]),
                    l = k !== u,
                    m = k === k;
                (g ? m || d : h ? m && l && (d || null != k) : i ? m && (d || l) : null == k ? 0 : d ? b >= k : b > k) ? e = j + 1: f = j
            }
            return ve(f, Be)
        }

        function Nb(a, b, c) {
            if ("function" != typeof a) return Id;
            if (b === u) return a;
            switch (c) {
                case 1:
                    return function(c) {
                        return a.call(b, c)
                    };
                case 3:
                    return function(c, d, e) {
                        return a.call(b, c, d, e)
                    };
                case 4:
                    return function(c, d, e, f) {
                        return a.call(b, c, d, e, f)
                    };
                case 5:
                    return function(c, d, e, f, g) {
                        return a.call(b, c, d, e, f, g)
                    }
            }
            return function() {
                return a.apply(b, arguments)
            }
        }

        function Ob(a) {
            var b = new ee(a.byteLength);
            return new me(b).set(new me(a)), b
        }

        function Pb(a, b, c) {
            for (var d = c.length, e = -1, f = ue(a.length - d, 0), g = -1, h = b.length, i = Nd(h + f); ++g < h;) i[g] = b[g];
            for (; ++e < d;) i[c[e]] = a[e];
            for (; f--;) i[g++] = a[e++];
            return i
        }

        function Qb(a, b, c) {
            for (var d = -1, e = c.length, f = -1, g = ue(a.length - e, 0), h = -1, i = b.length, j = Nd(g + i); ++f < g;) j[f] = a[f];
            for (g = f; ++h < i;) j[g + h] = b[h];
            for (; ++d < e;) j[g + c[d]] = a[f++];
            return j
        }

        function Rb(a, b) {
            return function(c, d, e) {
                var f = b ? b() : {};
                if (d = tc(d, e, 3), Bf(c)) {
                    e = -1;
                    for (var g = c.length; ++e < g;) {
                        var h = c[e];
                        a(f, h, d(h, e, c), c)
                    }
                } else He(c, function(b, c, e) {
                    a(f, b, d(b, c, e), e)
                });
                return f
            }
        }

        function Sb(a) {
            return jd(function(b, c) {
                var d = -1,
                    e = null == b ? 0 : c.length,
                    f = e > 2 ? c[e - 2] : u,
                    g = e > 2 ? c[2] : u,
                    h = e > 1 ? c[e - 1] : u;
                for ("function" == typeof f ? (f = Nb(f, h, 5), e -= 2) : (f = "function" == typeof h ? h : u, e -= f ? 1 : 0), g && Ec(c[0], c[1], g) && (f = 3 > e ? u : f, e = 1); ++d < e;)(g = c[d]) && a(b, g, f);
                return b
            })
        }

        function Tb(a, b) {
            return function(c, d) {
                var e = c ? Ne(c) : 0;
                if (!Hc(e)) return a(c, d);
                for (var f = b ? e : -1, g = Nc(c);
                    (b ? f-- : ++f < e) && !1 !== d(g[f], f, g););
                return c
            }
        }

        function Ub(a) {
            return function(b, c, d) {
                var e = Nc(b);
                d = d(b);
                for (var f = d.length, g = a ? f : -1; a ? g-- : ++g < f;) {
                    var h = d[g];
                    if (!1 === c(e[h], h, e)) break
                }
                return b
            }
        }

        function Vb(a, b) {
            function c() {
                return (this && this !== Ua && this instanceof c ? d : a).apply(b, arguments)
            }
            var d = Xb(a);
            return c
        }

        function Wb(a) {
            return function(b) {
                var c = -1;
                b = Gd(Dd(b));
                for (var d = b.length, e = ""; ++c < d;) e = a(e, b[c], c);
                return e
            }
        }

        function Xb(a) {
            return function() {
                var b = arguments;
                switch (b.length) {
                    case 0:
                        return new a;
                    case 1:
                        return new a(b[0]);
                    case 2:
                        return new a(b[0], b[1]);
                    case 3:
                        return new a(b[0], b[1], b[2]);
                    case 4:
                        return new a(b[0], b[1], b[2], b[3]);
                    case 5:
                        return new a(b[0], b[1], b[2], b[3], b[4]);
                    case 6:
                        return new a(b[0], b[1], b[2], b[3], b[4], b[5]);
                    case 7:
                        return new a(b[0], b[1], b[2], b[3], b[4], b[5], b[6])
                }
                var c = Ge(a.prototype),
                    b = a.apply(c, b);
                return pd(b) ? b : c
            }
        }

        function Yb(a) {
            function b(c, d, e) {
                return e && Ec(c, d, e) && (d = u), c = pc(c, a, u, u, u, u, u, d), c.placeholder = b.placeholder, c
            }
            return b
        }

        function Zb(a, b) {
            return jd(function(c) {
                var d = c[0];
                return null == d ? d : (c.push(b), a.apply(u, c))
            })
        }

        function $b(a, b) {
            return function(c, d, e) {
                if (e && Ec(c, d, e) && (d = u), d = tc(d, e, 3), 1 == d.length) {
                    e = c = Bf(c) ? c : Mc(c);
                    for (var f = d, g = -1, h = e.length, i = b, j = i; ++g < h;) {
                        var k = e[g],
                            l = +f(k);
                        a(l, i) && (i = l, j = k)
                    }
                    if (e = j, !c.length || e !== b) return e
                }
                return ib(c, d, a, b)
            }
        }

        function _b(a, c) {
            return function(d, e, f) {
                return e = tc(e, f, 3), Bf(d) ? (e = b(d, e, c), e > -1 ? d[e] : u) : kb(d, e, a)
            }
        }

        function ac(a) {
            return function(c, d, e) {
                return c && c.length ? (d = tc(d, e, 3), b(c, d, a)) : -1
            }
        }

        function bc(a) {
            return function(b, c, d) {
                return c = tc(c, d, 3), kb(b, c, a, !0)
            }
        }

        function cc(a) {
            return function() {
                for (var b, c = arguments.length, d = a ? c : -1, e = 0, f = Nd(c); a ? d-- : ++d < c;) {
                    var g = f[e++] = arguments[d];
                    if ("function" != typeof g) throw new Wd(M);
                    !b && La.prototype.thru && "wrapper" == uc(g) && (b = new La([], !0))
                }
                for (d = b ? -1 : c; ++d < c;) {
                    var g = f[d],
                        e = uc(g),
                        h = "wrapper" == e ? Me(g) : u;
                    b = h && Gc(h[0]) && h[1] == (D | z | B | E) && !h[4].length && 1 == h[9] ? b[uc(h[0])].apply(b, h[3]) : 1 == g.length && Gc(g) ? b[e]() : b.thru(g)
                }
                return function() {
                    var a = arguments,
                        d = a[0];
                    if (b && 1 == a.length && Bf(d) && d.length >= J) return b.plant(d).value();
                    for (var e = 0, a = c ? f[e].apply(this, a) : d; ++e < c;) a = f[e].call(this, a);
                    return a
                }
            }
        }

        function dc(a, b) {
            return function(c, d, e) {
                return "function" == typeof d && e === u && Bf(c) ? a(c, d) : b(c, Nb(d, e, 3))
            }
        }

        function ec(a) {
            return function(b, c, d) {
                return ("function" != typeof c || d !== u) && (c = Nb(c, d, 3)), a(b, c, Ad)
            }
        }

        function fc(a) {
            return function(b, c, d) {
                return ("function" != typeof c || d !== u) && (c = Nb(c, d, 3)), a(b, c)
            }
        }

        function gc(a) {
            return function(b, c, d) {
                var e = {};
                return c = tc(c, d, 3), nb(b, function(b, d, f) {
                    f = c(b, d, f), d = a ? f : d, b = a ? b : f, e[d] = b
                }), e
            }
        }

        function hc(a) {
            return function(b, c, d) {
                return b = e(b), (a ? b : "") + lc(b, c, d) + (a ? "" : b)
            }
        }

        function ic(a) {
            var b = jd(function(c, d) {
                var e = p(d, b.placeholder);
                return pc(c, a, u, d, e)
            });
            return b
        }

        function jc(a, b) {
            return function(c, d, e, f) {
                var g = 3 > arguments.length;
                return "function" == typeof d && f === u && Bf(c) ? a(c, d, e, g) : Bb(c, tc(d, f, 4), e, g, b)
            }
        }

        function kc(a, b, c, d, e, f, g, h, i, j) {
            function k() {
                for (var t = arguments.length, v = t, y = Nd(t); v--;) y[v] = arguments[v];
                if (d && (y = Pb(y, d, e)), f && (y = Qb(y, f, g)), o || r) {
                    var v = k.placeholder,
                        z = p(y, v),
                        t = t - z.length;
                    if (j > t) {
                        var A = h ? Qa(h) : u,
                            t = ue(j - t, 0),
                            D = o ? z : u,
                            z = o ? u : z,
                            E = o ? y : u,
                            y = o ? u : y;
                        return b |= o ? B : C, b &= ~(o ? C : B), q || (b &= ~(w | x)), y = [a, b, c, E, D, y, z, A, i, t], A = kc.apply(u, y), Gc(a) && Oe(A, y), A.placeholder = v, A
                    }
                }
                if (v = m ? c : this, A = n ? v[a] : a, h)
                    for (t = y.length, D = ve(h.length, t), z = Qa(y); D--;) E = h[D], y[D] = Dc(E, t) ? z[E] : u;
                return l && i < y.length && (y.length = i), this && this !== Ua && this instanceof k && (A = s || Xb(a)), A.apply(v, y)
            }
            var l = b & D,
                m = b & w,
                n = b & x,
                o = b & z,
                q = b & y,
                r = b & A,
                s = n ? u : Xb(a);
            return k
        }

        function lc(a, b, c) {
            return a = a.length, b = +b, b > a && se(b) ? (b -= a, c = null == c ? " " : c + "", Ed(c, oe(b / c.length)).slice(0, b)) : ""
        }

        function mc(a, b, c, d) {
            function e() {
                for (var b = -1, h = arguments.length, i = -1, j = d.length, k = Nd(j + h); ++i < j;) k[i] = d[i];
                for (; h--;) k[i++] = arguments[++b];
                return (this && this !== Ua && this instanceof e ? g : a).apply(f ? c : this, k)
            }
            var f = b & w,
                g = Xb(a);
            return e
        }

        function nc(a) {
            var b = Rd[a];
            return function(a, c) {
                return (c = c === u ? 0 : +c || 0) ? (c = he(10, c), b(a * c) / c) : b(a)
            }
        }

        function oc(a) {
            return function(b, c, d, e) {
                var f = tc(d);
                return null == d && f === db ? Lb(b, c, a) : Mb(b, c, f(d, e, 1), a)
            }
        }

        function pc(a, b, c, d, e, f, g, h) {
            var i = b & x;
            if (!i && "function" != typeof a) throw new Wd(M);
            var j = d ? d.length : 0;
            if (j || (b &= ~(B | C), d = e = u), j -= e ? e.length : 0, b & C) {
                var k = d,
                    l = e;
                d = e = u
            }
            var m = i ? u : Me(a);
            return c = [a, b, c, d, e, k, l, f, g, h], m && (d = c[1], b = m[1], h = d | b, e = b == D && d == z || b == D && d == E && c[7].length <= m[8] || b == (D | E) && d == z, (D > h || e) && (b & w && (c[2] = m[2], h |= d & w ? 0 : y), (d = m[3]) && (e = c[3], c[3] = e ? Pb(e, d, m[4]) : Qa(d), c[4] = e ? p(c[3], N) : Qa(m[4])), (d = m[5]) && (e = c[5], c[5] = e ? Qb(e, d, m[6]) : Qa(d), c[6] = e ? p(c[5], N) : Qa(m[6])), (d = m[7]) && (c[7] = Qa(d)), b & D && (c[8] = null == c[8] ? m[8] : ve(c[8], m[8])), null == c[9] && (c[9] = m[9]), c[0] = m[0], c[1] = h), b = c[1], h = c[9]), c[9] = null == h ? i ? 0 : a.length : ue(h - j, 0) || 0, (m ? Le : Oe)(b == w ? Vb(c[0], c[2]) : b != B && b != (w | B) || c[4].length ? kc.apply(u, c) : mc.apply(u, c), c)
        }

        function qc(a, b, c, d, e, f, g) {
            var h = -1,
                i = a.length,
                j = b.length;
            if (i != j && (!e || i >= j)) return !1;
            for (; ++h < i;) {
                var k = a[h],
                    j = b[h],
                    l = d ? d(e ? j : k, e ? k : j, h) : u;
                if (l !== u) {
                    if (l) continue;
                    return !1
                }
                if (e) {
                    if (!Za(b, function(a) {
                            return k === a || c(k, a, d, e, f, g)
                        })) return !1
                } else if (k !== j && !c(k, j, d, e, f, g)) return !1
            }
            return !0
        }

        function rc(a, b, c) {
            switch (c) {
                case Q:
                case R:
                    return +a == +b;
                case S:
                    return a.name == b.name && a.message == b.message;
                case U:
                    return a != +a ? b != +b : a == +b;
                case W:
                case X:
                    return a == b + ""
            }
            return !1
        }

        function sc(a, b, c, d, e, f, g) {
            var h = Mf(a),
                i = h.length,
                j = Mf(b).length;
            if (i != j && !e) return !1;
            for (j = i; j--;) {
                var k = h[j];
                if (!(e ? k in b : _d.call(b, k))) return !1
            }
            for (var l = e; ++j < i;) {
                var k = h[j],
                    m = a[k],
                    n = b[k],
                    o = d ? d(e ? n : m, e ? m : n, k) : u;
                if (o === u ? !c(m, n, d, e, f, g) : !o) return !1;
                l || (l = "constructor" == k)
            }
            return l || (c = a.constructor, d = b.constructor, !(c != d && "constructor" in a && "constructor" in b) || "function" == typeof c && c instanceof c && "function" == typeof d && d instanceof d) ? !0 : !1
        }

        function tc(a, b, c) {
            var d = Ja.callback || Hd,
                d = d === Hd ? db : d;
            return c ? d(a, b, c) : d
        }

        function uc(a) {
            for (var b = a.name + "", c = Fe[b], d = c ? c.length : 0; d--;) {
                var e = c[d],
                    f = e.func;
                if (null == f || f == a) return e.name
            }
            return b
        }

        function vc(a, b, d) {
            var e = Ja.indexOf || Tc,
                e = e === Tc ? c : e;
            return a ? e(a, b, d) : e
        }

        function wc(a) {
            a = Bd(a);
            for (var b = a.length; b--;) {
                var c = a[b][1];
                a[b][2] = c === c && !pd(c)
            }
            return a
        }

        function xc(a, b) {
            var c = null == a ? u : a[b];
            return qd(c) ? c : u
        }

        function yc(a) {
            var b = a.length,
                c = new a.constructor(b);
            return b && "string" == typeof a[0] && _d.call(a, "index") && (c.index = a.index, c.input = a.input), c
        }

        function zc(a) {
            return a = a.constructor, "function" == typeof a && a instanceof a || (a = Td), new a
        }

        function Ac(a, b, c) {
            var d = a.constructor;
            switch (b) {
                case Y:
                    return Ob(a);
                case Q:
                case R:
                    return new d(+a);
                case Z:
                case $:
                case _:
                case aa:
                case ba:
                case ca:
                case da:
                case ea:
                case fa:
                    return b = a.buffer, new d(c ? Ob(b) : b, a.byteOffset, a.length);
                case U:
                case X:
                    return new d(a);
                case W:
                    var e = new d(a.source, ya.exec(a));
                    e.lastIndex = a.lastIndex
            }
            return e
        }

        function Bc(a, b, c) {
            return null == a || Fc(b, a) || (b = Oc(b), a = 1 == b.length ? a : qb(a, Cb(b, 0, -1)), b = Uc(b)), b = null == a ? a : a[b], null == b ? u : b.apply(a, c)
        }

        function Cc(a) {
            return null != a && Hc(Ne(a))
        }

        function Dc(a, b) {
            return a = "number" == typeof a || Ba.test(a) ? +a : -1, b = null == b ? De : b, a > -1 && 0 == a % 1 && b > a
        }

        function Ec(a, b, c) {
            if (!pd(c)) return !1;
            var d = typeof b;
            return ("number" == d ? Cc(c) && Dc(b, c.length) : "string" == d && b in c) ? (b = c[b], a === a ? a === b : b !== b) : !1
        }

        function Fc(a, b) {
            var c = typeof a;
            return "string" == c && ra.test(a) || "number" == c ? !0 : Bf(a) ? !1 : !qa.test(a) || null != b && a in Nc(b)
        }

        function Gc(a) {
            var b = uc(a),
                c = Ja[b];
            return "function" == typeof c && b in Ma.prototype ? a === c ? !0 : (b = Me(c), !!b && a === b[0]) : !1
        }

        function Hc(a) {
            return "number" == typeof a && a > -1 && 0 == a % 1 && De >= a
        }

        function Ic(a, b) {
            return a === u ? b : Cf(a, b, Ic)
        }

        function Jc(a, b) {
            a = Nc(a);
            for (var c = -1, d = b.length, e = {}; ++c < d;) {
                var f = b[c];
                f in a && (e[f] = a[f])
            }
            return e
        }

        function Kc(a, b) {
            var c = {};
            return mb(a, function(a, d, e) {
                b(a, d, e) && (c[d] = a)
            }), c
        }

        function Lc(a) {
            for (var b = Ad(a), c = b.length, d = c && a.length, e = !!d && Hc(d) && (Bf(a) || ld(a)), f = -1, g = []; ++f < c;) {
                var h = b[f];
                (e && Dc(h, d) || _d.call(a, h)) && g.push(h)
            }
            return g
        }

        function Mc(a) {
            return null == a ? [] : Cc(a) ? pd(a) ? a : Td(a) : Cd(a)
        }

        function Nc(a) {
            return pd(a) ? a : Td(a)
        }

        function Oc(a) {
            if (Bf(a)) return a;
            var b = [];
            return e(a).replace(sa, function(a, c, d, e) {
                b.push(d ? e.replace(wa, "$1") : c || a)
            }), b
        }

        function Pc(a) {
            return a instanceof Ma ? a.clone() : new La(a.__wrapped__, a.__chain__, Qa(a.__actions__))
        }

        function Qc(a, b, c) {
            return a && a.length ? ((c ? Ec(a, b, c) : null == b) && (b = 1), Cb(a, 0 > b ? 0 : b)) : []
        }

        function Rc(a, b, c) {
            var d = a ? a.length : 0;
            return d ? ((c ? Ec(a, b, c) : null == b) && (b = 1), b = d - (+b || 0), Cb(a, 0, 0 > b ? 0 : b)) : []
        }

        function Sc(a) {
            return a ? a[0] : u
        }

        function Tc(a, b, d) {
            var e = a ? a.length : 0;
            if (!e) return -1;
            if ("number" == typeof d) d = 0 > d ? ue(e + d, 0) : d;
            else if (d) return d = Lb(a, b), e > d && (b === b ? b === a[d] : a[d] !== a[d]) ? d : -1;
            return c(a, b, d || 0)
        }

        function Uc(a) {
            var b = a ? a.length : 0;
            return b ? a[b - 1] : u
        }

        function Vc(a) {
            return Qc(a, 1)
        }

        function Wc(a, b, d, e) {
            if (!a || !a.length) return [];
            null != b && "boolean" != typeof b && (e = d, d = Ec(a, b, e) ? u : b, b = !1);
            var f = tc();
            if ((null != d || f !== db) && (d = f(d, e, 3)), b && vc() === c) {
                b = d;
                var g;
                d = -1, e = a.length;
                for (var f = -1, h = []; ++d < e;) {
                    var i = a[d],
                        j = b ? b(i, d, a) : i;
                    d && g === j || (g = j, h[++f] = i)
                }
                a = h
            } else a = Hb(a, d);
            return a
        }

        function Xc(a) {
            if (!a || !a.length) return [];
            var b = -1,
                c = 0;
            a = Ta(a, function(a) {
                return Cc(a) ? (c = ue(a.length, c), !0) : void 0
            });
            for (var d = Nd(c); ++b < c;) d[b] = Wa(a, xb(b));
            return d
        }

        function Yc(a, b, c) {
            return a && a.length ? (a = Xc(a), null == b ? a : (b = Nb(b, c, 4), Wa(a, function(a) {
                return Ya(a, b, u, !0)
            }))) : []
        }

        function Zc(a, b) {
            var c = -1,
                d = a ? a.length : 0,
                e = {};
            for (!d || b || Bf(a[0]) || (b = []); ++c < d;) {
                var f = a[c];
                b ? e[f] = b[c] : f && (e[f[0]] = f[1])
            }
            return e
        }

        function $c(a) {
            return a = Ja(a), a.__chain__ = !0, a
        }

        function _c(a, b, c) {
            return b.call(c, a)
        }

        function ad(a, b, c) {
            var d = Bf(a) ? Sa : hb;
            return c && Ec(a, b, c) && (b = u), ("function" != typeof b || c !== u) && (b = tc(b, c, 3)), d(a, b)
        }

        function bd(a, b, c) {
            var d = Bf(a) ? Ta : jb;
            return b = tc(b, c, 3), d(a, b)
        }

        function cd(a, b, c, d) {
            var e = a ? Ne(a) : 0;
            return Hc(e) || (a = Cd(a), e = a.length), c = "number" != typeof c || d && Ec(b, c, d) ? 0 : 0 > c ? ue(e + c, 0) : c || 0, "string" == typeof a || !Bf(a) && ud(a) ? e >= c && -1 < a.indexOf(b, c) : !!e && -1 < vc(a, b, c)
        }

        function dd(a, b, c) {
            var d = Bf(a) ? Wa : tb;
            return b = tc(b, c, 3), d(a, b)
        }

        function ed(a, b, c) {
            if (c ? Ec(a, b, c) : null == b) {
                a = Mc(a);
                var d = a.length;
                return d > 0 ? a[Ab(0, d - 1)] : u
            }
            c = -1, a = xd(a);
            var d = a.length,
                e = d - 1;
            for (b = ve(0 > b ? 0 : +b || 0, d); ++c < b;) {
                var d = Ab(c, e),
                    f = a[d];
                a[d] = a[c], a[c] = f
            }
            return a.length = b, a
        }

        function fd(a, b, c) {
            var d = Bf(a) ? Za : Db;
            return c && Ec(a, b, c) && (b = u), ("function" != typeof b || c !== u) && (b = tc(b, c, 3)), d(a, b)
        }

        function gd(a, b) {
            var c;
            if ("function" != typeof b) {
                if ("function" != typeof a) throw new Wd(M);
                var d = a;
                a = b, b = d
            }
            return function() {
                return 0 < --a && (c = b.apply(this, arguments)), 1 >= a && (b = u), c
            }
        }

        function hd(a, b, c) {
            function d(b, c) {
                c && fe(c), i = m = n = u, b && (o = nf(), j = a.apply(l, h), m || i || (h = l = u))
            }

            function e() {
                var a = b - (nf() - k);
                0 >= a || a > b ? d(n, i) : m = ke(e, a)
            }

            function f() {
                d(q, m)
            }

            function g() {
                if (h = arguments, k = nf(), l = this, n = q && (m || !r), !1 === p) var c = r && !m;
                else {
                    i || r || (o = k);
                    var d = p - (k - o),
                        g = 0 >= d || d > p;
                    g ? (i && (i = fe(i)), o = k, j = a.apply(l, h)) : i || (i = ke(f, d))
                }
                return g && m ? m = fe(m) : m || b === p || (m = ke(e, b)), c && (g = !0, j = a.apply(l, h)), !g || m || i || (h = l = u), j
            }
            var h, i, j, k, l, m, n, o = 0,
                p = !1,
                q = !0;
            if ("function" != typeof a) throw new Wd(M);
            if (b = 0 > b ? 0 : +b || 0, !0 === c) var r = !0,
                q = !1;
            else pd(c) && (r = !!c.leading, p = "maxWait" in c && ue(+c.maxWait || 0, b), q = "trailing" in c ? !!c.trailing : q);
            return g.cancel = function() {
                m && fe(m), i && fe(i), o = 0, i = m = n = u
            }, g
        }

        function id(a, b) {
            function c() {
                var d = arguments,
                    e = b ? b.apply(this, d) : d[0],
                    f = c.cache;
                return f.has(e) ? f.get(e) : (d = a.apply(this, d), c.cache = f.set(e, d), d)
            }
            if ("function" != typeof a || b && "function" != typeof b) throw new Wd(M);
            return c.cache = new id.Cache, c
        }

        function jd(a, b) {
            if ("function" != typeof a) throw new Wd(M);
            return b = ue(b === u ? a.length - 1 : +b || 0, 0),
                function() {
                    for (var c = arguments, d = -1, e = ue(c.length - b, 0), f = Nd(e); ++d < e;) f[d] = c[b + d];
                    switch (b) {
                        case 0:
                            return a.call(this, f);
                        case 1:
                            return a.call(this, c[0], f);
                        case 2:
                            return a.call(this, c[0], c[1], f)
                    }
                    for (e = Nd(b + 1), d = -1; ++d < b;) e[d] = c[d];
                    return e[b] = f, a.apply(this, e)
                }
        }

        function kd(a, b) {
            return a > b
        }

        function ld(a) {
            return n(a) && Cc(a) && _d.call(a, "callee") && !ie.call(a, "callee")
        }

        function md(a, b, c, d) {
            return d = (c = "function" == typeof c ? Nb(c, d, 3) : u) ? c(a, b) : u, d === u ? rb(a, b, c) : !!d
        }

        function nd(a) {
            return n(a) && "string" == typeof a.message && be.call(a) == S
        }

        function od(a) {
            return pd(a) && be.call(a) == T
        }

        function pd(a) {
            var b = typeof a;
            return !!a && ("object" == b || "function" == b)
        }

        function qd(a) {
            return null == a ? !1 : od(a) ? de.test($d.call(a)) : n(a) && Aa.test(a)
        }

        function rd(a) {
            return "number" == typeof a || n(a) && be.call(a) == U
        }

        function sd(a) {
            var b;
            if (!n(a) || be.call(a) != V || ld(a) || !(_d.call(a, "constructor") || (b = a.constructor, "function" != typeof b || b instanceof b))) return !1;
            var c;
            return mb(a, function(a, b) {
                c = b
            }), c === u || _d.call(a, c)
        }

        function td(a) {
            return pd(a) && be.call(a) == W
        }

        function ud(a) {
            return "string" == typeof a || n(a) && be.call(a) == X
        }

        function vd(a) {
            return n(a) && Hc(a.length) && !!Ha[be.call(a)]
        }

        function wd(a, b) {
            return b > a
        }

        function xd(a) {
            var b = a ? Ne(a) : 0;
            return Hc(b) ? b ? Qa(a) : [] : Cd(a)
        }

        function yd(a) {
            return cb(a, Ad(a))
        }

        function zd(a) {
            return pb(a, Ad(a))
        }

        function Ad(a) {
            if (null == a) return [];
            pd(a) || (a = Td(a));
            for (var b = a.length, b = b && Hc(b) && (Bf(a) || ld(a)) && b || 0, c = a.constructor, d = -1, c = "function" == typeof c && c.prototype === a, e = Nd(b), f = b > 0; ++d < b;) e[d] = d + "";
            for (var g in a) f && Dc(g, b) || "constructor" == g && (c || !_d.call(a, g)) || e.push(g);
            return e
        }

        function Bd(a) {
            a = Nc(a);
            for (var b = -1, c = Mf(a), d = c.length, e = Nd(d); ++b < d;) {
                var f = c[b];
                e[b] = [f, a[f]]
            }
            return e
        }

        function Cd(a) {
            return Ib(a, Mf(a))
        }

        function Dd(a) {
            return (a = e(a)) && a.replace(Ca, i).replace(va, "")
        }

        function Ed(a, b) {
            var c = "";
            if (a = e(a), b = +b, 1 > b || !a || !se(b)) return c;
            do b % 2 && (c += a), b = qe(b / 2), a += a; while (b);
            return c
        }

        function Fd(a, b, c) {
            var d = a;
            return (a = e(a)) ? (c ? Ec(d, b, c) : null == b) ? a.slice(q(a), r(a) + 1) : (b += "", a.slice(f(a, b), g(a, b) + 1)) : a
        }

        function Gd(a, b, c) {
            return c && Ec(a, b, c) && (b = u), a = e(a), a.match(b || Fa) || []
        }

        function Hd(a, b, c) {
            return c && Ec(a, b, c) && (b = u), n(a) ? Jd(a) : db(a, b)
        }

        function Id(a) {
            return a
        }

        function Jd(a) {
            return ub(eb(a, !0))
        }

        function Kd(a, b, c) {
            if (null == c) {
                var d = pd(b),
                    e = d ? Mf(b) : u;
                ((e = e && e.length ? pb(b, e) : u) ? e.length : d) || (e = !1, c = b, b = a, a = this)
            }
            e || (e = pb(b, Mf(b)));
            var f = !0,
                d = -1,
                g = od(a),
                h = e.length;
            !1 === c ? f = !1 : pd(c) && "chain" in c && (f = c.chain);
            for (; ++d < h;) {
                c = e[d];
                var i = b[c];
                a[c] = i, g && (a.prototype[c] = function(b) {
                    return function() {
                        var c = this.__chain__;
                        if (f || c) {
                            var d = a(this.__wrapped__);
                            return (d.__actions__ = Qa(this.__actions__)).push({
                                func: b,
                                args: arguments,
                                thisArg: a
                            }), d.__chain__ = c, d
                        }
                        return b.apply(a, Xa([this.value()], arguments))
                    }
                }(i))
            }
            return a
        }

        function Ld() {}

        function Md(a) {
            return Fc(a) ? xb(a) : yb(a)
        }
        o = o ? Va.defaults(Ua.Object(), o, Va.pick(Ua, Ga)) : Ua;
        var Nd = o.Array,
            Od = o.Date,
            Pd = o.Error,
            Qd = o.Function,
            Rd = o.Math,
            Sd = o.Number,
            Td = o.Object,
            Ud = o.RegExp,
            Vd = o.String,
            Wd = o.TypeError,
            Xd = Nd.prototype,
            Yd = Td.prototype,
            Zd = Vd.prototype,
            $d = Qd.prototype.toString,
            _d = Yd.hasOwnProperty,
            ae = 0,
            be = Yd.toString,
            ce = Ua._,
            de = Ud("^" + $d.call(_d).replace(/[\\^$.*+?()[\]{}|]/g, "\\$&").replace(/hasOwnProperty|(function).*?(?=\\\()| for .+?(?=\\\])/g, "$1.*?") + "$"),
            ee = o.ArrayBuffer,
            fe = o.clearTimeout,
            ge = o.parseFloat,
            he = Rd.pow,
            ie = Yd.propertyIsEnumerable,
            je = xc(o, "Set"),
            ke = o.setTimeout,
            le = Xd.splice,
            me = o.Uint8Array,
            ne = xc(o, "WeakMap"),
            oe = Rd.ceil,
            pe = xc(Td, "create"),
            qe = Rd.floor,
            re = xc(Nd, "isArray"),
            se = o.isFinite,
            te = xc(Td, "keys"),
            ue = Rd.max,
            ve = Rd.min,
            we = xc(Od, "now"),
            xe = o.parseInt,
            ye = Rd.random,
            ze = Sd.NEGATIVE_INFINITY,
            Ae = Sd.POSITIVE_INFINITY,
            Be = 4294967294,
            Ce = 2147483647,
            De = 9007199254740991,
            Ee = ne && new ne,
            Fe = {};
        Ja.support = {}, Ja.templateSettings = {
            escape: na,
            evaluate: oa,
            interpolate: pa,
            variable: "",
            imports: {
                _: Ja
            }
        };
        var Ge = function() {
                function a() {}
                return function(b) {
                    if (pd(b)) {
                        a.prototype = b;
                        var c = new a;
                        a.prototype = u
                    }
                    return c || {}
                }
            }(),
            He = Tb(nb),
            Ie = Tb(ob, !0),
            Je = Ub(),
            Ke = Ub(!0),
            Le = Ee ? function(a, b) {
                return Ee.set(a, b), a
            } : Id,
            Me = Ee ? function(a) {
                return Ee.get(a)
            } : Ld,
            Ne = xb("length"),
            Oe = function() {
                var a = 0,
                    b = 0;
                return function(c, d) {
                    var e = nf(),
                        f = I - (e - b);
                    if (b = e, f > 0) {
                        if (++a >= H) return c
                    } else a = 0;
                    return Le(c, d)
                }
            }(),
            Pe = jd(function(a, b) {
                return n(a) && Cc(a) ? gb(a, lb(b, !1, !0)) : []
            }),
            Qe = ac(),
            Re = ac(!0),
            Se = jd(function(a) {
                for (var b = a.length, d = b, e = Nd(k), f = vc(), g = f === c, h = []; d--;) {
                    var i = a[d] = Cc(i = a[d]) ? i : [];
                    e[d] = g && 120 <= i.length && pe && je ? new Oa(d && i) : null
                }
                var g = a[0],
                    j = -1,
                    k = g ? g.length : 0,
                    l = e[0];
                a: for (; ++j < k;)
                    if (i = g[j], 0 > (l ? Pa(l, i) : f(h, i, 0))) {
                        for (d = b; --d;) {
                            var m = e[d];
                            if (0 > (m ? Pa(m, i) : f(a[d], i, 0))) continue a
                        }
                        l && l.push(i), h.push(i)
                    }
                return h
            }),
            Te = jd(function(b, c) {
                c = lb(c);
                var d = bb(b, c);
                return zb(b, c.sort(a)), d
            }),
            Ue = oc(),
            Ve = oc(!0),
            We = jd(function(a) {
                return Hb(lb(a, !1, !0))
            }),
            Xe = jd(function(a, b) {
                return Cc(a) ? gb(a, b) : []
            }),
            Ye = jd(Xc),
            Ze = jd(function(a) {
                var b = a.length,
                    c = b > 2 ? a[b - 2] : u,
                    d = b > 1 ? a[b - 1] : u;
                return b > 2 && "function" == typeof c ? b -= 2 : (c = b > 1 && "function" == typeof d ? (--b, d) : u, d = u), a.length = b, Yc(a, c, d)
            }),
            $e = jd(function(a) {
                return a = lb(a), this.thru(function(b) {
                    b = Bf(b) ? b : [Nc(b)];
                    for (var c = a, d = -1, e = b.length, f = -1, g = c.length, h = Nd(e + g); ++d < e;) h[d] = b[d];
                    for (; ++f < g;) h[d++] = c[f];
                    return h
                })
            }),
            _e = jd(function(a, b) {
                return bb(a, lb(b))
            }),
            af = Rb(function(a, b, c) {
                _d.call(a, c) ? ++a[c] : a[c] = 1
            }),
            bf = _b(He),
            cf = _b(Ie, !0),
            df = dc(Ra, He),
            ef = dc(function(a, b) {
                for (var c = a.length; c-- && !1 !== b(a[c], c, a););
                return a
            }, Ie),
            ff = Rb(function(a, b, c) {
                _d.call(a, c) ? a[c].push(b) : a[c] = [b]
            }),
            gf = Rb(function(a, b, c) {
                a[c] = b
            }),
            hf = jd(function(a, b, c) {
                var d = -1,
                    e = "function" == typeof b,
                    f = Fc(b),
                    g = Cc(a) ? Nd(a.length) : [];
                return He(a, function(a) {
                    var h = e ? b : f && null != a ? a[b] : u;
                    g[++d] = h ? h.apply(a, c) : Bc(a, b, c)
                }), g
            }),
            jf = Rb(function(a, b, c) {
                a[c ? 0 : 1].push(b)
            }, function() {
                return [
                    [],
                    []
                ]
            }),
            kf = jc(Ya, He),
            lf = jc(function(a, b, c, d) {
                var e = a.length;
                for (d && e && (c = a[--e]); e--;) c = b(c, a[e], e, a);
                return c
            }, Ie),
            mf = jd(function(a, b) {
                if (null == a) return [];
                var c = b[2];
                return c && Ec(b[0], b[1], c) && (b.length = 1), Fb(a, lb(b), [])
            }),
            nf = we || function() {
                return (new Od).getTime()
            },
            of = jd(function(a, b, c) {
                var d = w;
                if (c.length) var e = p(c, of.placeholder),
                    d = d | B;
                return pc(a, d, b, c, e)
            }),
            pf = jd(function(a, b) {
                b = b.length ? lb(b) : zd(a);
                for (var c = -1, d = b.length; ++c < d;) {
                    var e = b[c];
                    a[e] = pc(a[e], w, a)
                }
                return a
            }),
            qf = jd(function(a, b, c) {
                var d = w | x;
                if (c.length) var e = p(c, qf.placeholder),
                    d = d | B;
                return pc(b, d, a, c, e)
            }),
            rf = Yb(z),
            sf = Yb(A),
            tf = jd(function(a, b) {
                return fb(a, 1, b)
            }),
            uf = jd(function(a, b, c) {
                return fb(a, b, c)
            }),
            vf = cc(),
            wf = cc(!0),
            xf = jd(function(a, b) {
                if (b = lb(b), "function" != typeof a || !Sa(b, d)) throw new Wd(M);
                var c = b.length;
                return jd(function(d) {
                    for (var e = ve(d.length, c); e--;) d[e] = b[e](d[e]);
                    return a.apply(this, d)
                })
            }),
            yf = ic(B),
            zf = ic(C),
            Af = jd(function(a, b) {
                return pc(a, E, u, u, u, lb(b))
            }),
            Bf = re || function(a) {
                return n(a) && Hc(a.length) && be.call(a) == P
            },
            Cf = Sb(wb),
            Df = Sb(function(a, b, c) {
                return c ? _a(a, b, c) : ab(a, b)
            }),
            Ef = Zb(Df, function(a, b) {
                return a === u ? b : a
            }),
            Ff = Zb(Cf, Ic),
            Gf = bc(nb),
            Hf = bc(ob),
            If = ec(Je),
            Jf = ec(Ke),
            Kf = fc(nb),
            Lf = fc(ob),
            Mf = te ? function(a) {
                var b = null == a ? u : a.constructor;
                return "function" == typeof b && b.prototype === a || "function" != typeof a && Cc(a) ? Lc(a) : pd(a) ? te(a) : []
            } : Lc,
            Nf = gc(!0),
            Of = gc(),
            Pf = jd(function(a, b) {
                if (null == a) return {};
                if ("function" != typeof b[0]) return b = Wa(lb(b), Vd), Jc(a, gb(Ad(a), b));
                var c = Nb(b[0], b[1], 3);
                return Kc(a, function(a, b, d) {
                    return !c(a, b, d)
                })
            }),
            Qf = jd(function(a, b) {
                return null == a ? {} : "function" == typeof b[0] ? Kc(a, Nb(b[0], b[1], 3)) : Jc(a, lb(b))
            }),
            Rf = Wb(function(a, b, c) {
                return b = b.toLowerCase(), a + (c ? b.charAt(0).toUpperCase() + b.slice(1) : b)
            }),
            Sf = Wb(function(a, b, c) {
                return a + (c ? "-" : "") + b.toLowerCase()
            }),
            Tf = hc(),
            Uf = hc(!0),
            Vf = Wb(function(a, b, c) {
                return a + (c ? "_" : "") + b.toLowerCase()
            }),
            Wf = Wb(function(a, b, c) {
                return a + (c ? " " : "") + (b.charAt(0).toUpperCase() + b.slice(1))
            }),
            Xf = jd(function(a, b) {
                try {
                    return a.apply(u, b)
                } catch (c) {
                    return nd(c) ? c : new Pd(c)
                }
            }),
            Yf = jd(function(a, b) {
                return function(c) {
                    return Bc(c, a, b)
                }
            }),
            Zf = jd(function(a, b) {
                return function(c) {
                    return Bc(a, c, b)
                }
            }),
            $f = nc("ceil"),
            _f = nc("floor"),
            ag = $b(kd, ze),
            bg = $b(wd, Ae),
            cg = nc("round");
        return Ja.prototype = Ka.prototype, La.prototype = Ge(Ka.prototype), La.prototype.constructor = La, Ma.prototype = Ge(Ka.prototype), Ma.prototype.constructor = Ma, Na.prototype["delete"] = function(a) {
            return this.has(a) && delete this.__data__[a]
        }, Na.prototype.get = function(a) {
            return "__proto__" == a ? u : this.__data__[a]
        }, Na.prototype.has = function(a) {
            return "__proto__" != a && _d.call(this.__data__, a)
        }, Na.prototype.set = function(a, b) {
            return "__proto__" != a && (this.__data__[a] = b), this
        }, Oa.prototype.push = function(a) {
            var b = this.data;
            "string" == typeof a || pd(a) ? b.set.add(a) : b.hash[a] = !0
        }, id.Cache = Na, Ja.after = function(a, b) {
            if ("function" != typeof b) {
                if ("function" != typeof a) throw new Wd(M);
                var c = a;
                a = b, b = c
            }
            return a = se(a = +a) ? a : 0,
                function() {
                    return 1 > --a ? b.apply(this, arguments) : void 0
                }
        }, Ja.ary = function(a, b, c) {
            return c && Ec(a, b, c) && (b = u), b = a && null == b ? a.length : ue(+b || 0, 0), pc(a, D, u, u, u, u, b)
        }, Ja.assign = Df, Ja.at = _e, Ja.before = gd, Ja.bind = of, Ja.bindAll = pf, Ja.bindKey = qf, Ja.callback = Hd, Ja.chain = $c, Ja.chunk = function(a, b, c) {
            b = (c ? Ec(a, b, c) : null == b) ? 1 : ue(qe(b) || 1, 1), c = 0;
            for (var d = a ? a.length : 0, e = -1, f = Nd(oe(d / b)); d > c;) f[++e] = Cb(a, c, c += b);
            return f
        }, Ja.compact = function(a) {
            for (var b = -1, c = a ? a.length : 0, d = -1, e = []; ++b < c;) {
                var f = a[b];
                f && (e[++d] = f)
            }
            return e
        }, Ja.constant = function(a) {
            return function() {
                return a
            }
        }, Ja.countBy = af, Ja.create = function(a, b, c) {
            var d = Ge(a);
            return c && Ec(a, b, c) && (b = u), b ? ab(d, b) : d
        }, Ja.curry = rf, Ja.curryRight = sf, Ja.debounce = hd, Ja.defaults = Ef, Ja.defaultsDeep = Ff, Ja.defer = tf, Ja.delay = uf, Ja.difference = Pe, Ja.drop = Qc, Ja.dropRight = Rc, Ja.dropRightWhile = function(a, b, c) {
            return a && a.length ? Jb(a, tc(b, c, 3), !0, !0) : []
        }, Ja.dropWhile = function(a, b, c) {
            return a && a.length ? Jb(a, tc(b, c, 3), !0) : []
        }, Ja.fill = function(a, b, c, d) {
            var e = a ? a.length : 0;
            if (!e) return [];
            for (c && "number" != typeof c && Ec(a, b, c) && (c = 0, d = e), e = a.length, c = null == c ? 0 : +c || 0, 0 > c && (c = -c > e ? 0 : e + c), d = d === u || d > e ? e : +d || 0, 0 > d && (d += e), e = c > d ? 0 : d >>> 0, c >>>= 0; e > c;) a[c++] = b;
            return a
        }, Ja.filter = bd, Ja.flatten = function(a, b, c) {
            var d = a ? a.length : 0;
            return c && Ec(a, b, c) && (b = !1), d ? lb(a, b) : []
        }, Ja.flattenDeep = function(a) {
            return a && a.length ? lb(a, !0) : []
        }, Ja.flow = vf, Ja.flowRight = wf, Ja.forEach = df, Ja.forEachRight = ef, Ja.forIn = If, Ja.forInRight = Jf, Ja.forOwn = Kf, Ja.forOwnRight = Lf, Ja.functions = zd, Ja.groupBy = ff, Ja.indexBy = gf, Ja.initial = function(a) {
            return Rc(a, 1)
        }, Ja.intersection = Se, Ja.invert = function(a, b, c) {
            c && Ec(a, b, c) && (b = u), c = -1;
            for (var d = Mf(a), e = d.length, f = {}; ++c < e;) {
                var g = d[c],
                    h = a[g];
                b ? _d.call(f, h) ? f[h].push(g) : f[h] = [g] : f[h] = g
            }
            return f
        }, Ja.invoke = hf, Ja.keys = Mf, Ja.keysIn = Ad, Ja.map = dd, Ja.mapKeys = Nf, Ja.mapValues = Of, Ja.matches = Jd, Ja.matchesProperty = function(a, b) {
            return vb(a, eb(b, !0))
        }, Ja.memoize = id, Ja.merge = Cf, Ja.method = Yf, Ja.methodOf = Zf, Ja.mixin = Kd, Ja.modArgs = xf, Ja.negate = function(a) {
            if ("function" != typeof a) throw new Wd(M);
            return function() {
                return !a.apply(this, arguments)
            }
        }, Ja.omit = Pf, Ja.once = function(a) {
            return gd(2, a)
        }, Ja.pairs = Bd, Ja.partial = yf, Ja.partialRight = zf, Ja.partition = jf, Ja.pick = Qf, Ja.pluck = function(a, b) {
            return dd(a, Md(b))
        }, Ja.property = Md, Ja.propertyOf = function(a) {
            return function(b) {
                return qb(a, Oc(b), b + "")
            }
        }, Ja.pull = function() {
            var a = arguments,
                b = a[0];
            if (!b || !b.length) return b;
            for (var c = 0, d = vc(), e = a.length; ++c < e;)
                for (var f = 0, g = a[c]; - 1 < (f = d(b, g, f));) le.call(b, f, 1);
            return b
        }, Ja.pullAt = Te, Ja.range = function(a, b, c) {
            c && Ec(a, b, c) && (b = c = u), a = +a || 0, c = null == c ? 1 : +c || 0, null == b ? (b = a, a = 0) : b = +b || 0;
            var d = -1;
            b = ue(oe((b - a) / (c || 1)), 0);
            for (var e = Nd(b); ++d < b;) e[d] = a, a += c;
            return e
        }, Ja.rearg = Af, Ja.reject = function(a, b, c) {
            var d = Bf(a) ? Ta : jb;
            return b = tc(b, c, 3), d(a, function(a, c, d) {
                return !b(a, c, d)
            })
        }, Ja.remove = function(a, b, c) {
            var d = [];
            if (!a || !a.length) return d;
            var e = -1,
                f = [],
                g = a.length;
            for (b = tc(b, c, 3); ++e < g;) c = a[e], b(c, e, a) && (d.push(c), f.push(e));
            return zb(a, f), d
        }, Ja.rest = Vc, Ja.restParam = jd, Ja.set = function(a, b, c) {
            if (null == a) return a;
            var d = b + "";
            b = null != a[d] || Fc(b, a) ? [d] : Oc(b);
            for (var d = -1, e = b.length, f = e - 1, g = a; null != g && ++d < e;) {
                var h = b[d];
                pd(g) && (d == f ? g[h] = c : null == g[h] && (g[h] = Dc(b[d + 1]) ? [] : {})), g = g[h]
            }
            return a
        }, Ja.shuffle = function(a) {
            return ed(a, Ae)
        }, Ja.slice = function(a, b, c) {
            var d = a ? a.length : 0;
            return d ? (c && "number" != typeof c && Ec(a, b, c) && (b = 0, c = d), Cb(a, b, c)) : []
        }, Ja.sortBy = function(a, b, c) {
            if (null == a) return [];
            c && Ec(a, b, c) && (b = u);
            var d = -1;
            return b = tc(b, c, 3), a = tb(a, function(a, c, e) {
                return {
                    a: b(a, c, e),
                    b: ++d,
                    c: a
                }
            }), Eb(a, h)
        }, Ja.sortByAll = mf, Ja.sortByOrder = function(a, b, c, d) {
            return null == a ? [] : (d && Ec(b, c, d) && (c = u), Bf(b) || (b = null == b ? [] : [b]), Bf(c) || (c = null == c ? [] : [c]), Fb(a, b, c))
        }, Ja.spread = function(a) {
            if ("function" != typeof a) throw new Wd(M);
            return function(b) {
                return a.apply(this, b)
            }
        }, Ja.take = function(a, b, c) {
            return a && a.length ? ((c ? Ec(a, b, c) : null == b) && (b = 1), Cb(a, 0, 0 > b ? 0 : b)) : []
        }, Ja.takeRight = function(a, b, c) {
            var d = a ? a.length : 0;
            return d ? ((c ? Ec(a, b, c) : null == b) && (b = 1), b = d - (+b || 0), Cb(a, 0 > b ? 0 : b)) : []
        }, Ja.takeRightWhile = function(a, b, c) {
            return a && a.length ? Jb(a, tc(b, c, 3), !1, !0) : []
        }, Ja.takeWhile = function(a, b, c) {
            return a && a.length ? Jb(a, tc(b, c, 3)) : []
        }, Ja.tap = function(a, b, c) {
            return b.call(c, a), a
        }, Ja.throttle = function(a, b, c) {
            var d = !0,
                e = !0;
            if ("function" != typeof a) throw new Wd(M);
            return !1 === c ? d = !1 : pd(c) && (d = "leading" in c ? !!c.leading : d, e = "trailing" in c ? !!c.trailing : e), hd(a, b, {
                leading: d,
                maxWait: +b,
                trailing: e
            })
        }, Ja.thru = _c, Ja.times = function(a, b, c) {
            if (a = qe(a), 1 > a || !se(a)) return [];
            var d = -1,
                e = Nd(ve(a, 4294967295));
            for (b = Nb(b, c, 1); ++d < a;) 4294967295 > d ? e[d] = b(d) : b(d);
            return e
        }, Ja.toArray = xd, Ja.toPlainObject = yd, Ja.transform = function(a, b, c, d) {
            var e = Bf(a) || vd(a);
            return b = tc(b, d, 4), null == c && (e || pd(a) ? (d = a.constructor, c = e ? Bf(a) ? new d : [] : Ge(od(d) ? d.prototype : u)) : c = {}), (e ? Ra : nb)(a, function(a, d, e) {
                return b(c, a, d, e)
            }), c
        }, Ja.union = We, Ja.uniq = Wc, Ja.unzip = Xc, Ja.unzipWith = Yc, Ja.values = Cd, Ja.valuesIn = function(a) {
            return Ib(a, Ad(a))
        }, Ja.where = function(a, b) {
            return bd(a, ub(b))
        }, Ja.without = Xe, Ja.wrap = function(a, b) {
            return b = null == b ? Id : b, pc(b, B, u, [a], [])
        }, Ja.xor = function() {
            for (var a = -1, b = arguments.length; ++a < b;) {
                var c = arguments[a];
                if (Cc(c)) var d = d ? Xa(gb(d, c), gb(c, d)) : c
            }
            return d ? Hb(d) : []
        }, Ja.zip = Ye, Ja.zipObject = Zc, Ja.zipWith = Ze, Ja.backflow = wf, Ja.collect = dd, Ja.compose = wf, Ja.each = df, Ja.eachRight = ef, Ja.extend = Df, Ja.iteratee = Hd, Ja.methods = zd, Ja.object = Zc, Ja.select = bd, Ja.tail = Vc, Ja.unique = Wc, Kd(Ja, Ja), Ja.add = function(a, b) {
            return (+a || 0) + (+b || 0)
        }, Ja.attempt = Xf, Ja.camelCase = Rf, Ja.capitalize = function(a) {
            return (a = e(a)) && a.charAt(0).toUpperCase() + a.slice(1)
        }, Ja.ceil = $f, Ja.clone = function(a, b, c, d) {
            return b && "boolean" != typeof b && Ec(a, b, c) ? b = !1 : "function" == typeof b && (d = c, c = b, b = !1), "function" == typeof c ? eb(a, b, Nb(c, d, 3)) : eb(a, b)
        }, Ja.cloneDeep = function(a, b, c) {
            return "function" == typeof b ? eb(a, !0, Nb(b, c, 3)) : eb(a, !0)
        }, Ja.deburr = Dd, Ja.endsWith = function(a, b, c) {
            a = e(a), b += "";
            var d = a.length;
            return c = c === u ? d : ve(0 > c ? 0 : +c || 0, d), c -= b.length, c >= 0 && a.indexOf(b, c) == c
        }, Ja.escape = function(a) {
            return (a = e(a)) && ma.test(a) ? a.replace(ka, j) : a
        }, Ja.escapeRegExp = function(a) {
            return (a = e(a)) && ua.test(a) ? a.replace(ta, k) : a || "(?:)"
        }, Ja.every = ad, Ja.find = bf, Ja.findIndex = Qe, Ja.findKey = Gf, Ja.findLast = cf, Ja.findLastIndex = Re, Ja.findLastKey = Hf, Ja.findWhere = function(a, b) {
            return bf(a, ub(b))
        }, Ja.first = Sc, Ja.floor = _f, Ja.get = function(a, b, c) {
            return a = null == a ? u : qb(a, Oc(b), b + ""), a === u ? c : a
        }, Ja.gt = kd, Ja.gte = function(a, b) {
            return a >= b
        }, Ja.has = function(a, b) {
            if (null == a) return !1;
            var c = _d.call(a, b);
            if (!c && !Fc(b)) {
                if (b = Oc(b), a = 1 == b.length ? a : qb(a, Cb(b, 0, -1)), null == a) return !1;
                b = Uc(b), c = _d.call(a, b)
            }
            return c || Hc(a.length) && Dc(b, a.length) && (Bf(a) || ld(a))
        }, Ja.identity = Id, Ja.includes = cd, Ja.indexOf = Tc, Ja.inRange = function(a, b, c) {
            return b = +b || 0, c === u ? (c = b, b = 0) : c = +c || 0, a >= ve(b, c) && a < ue(b, c)
        }, Ja.isArguments = ld, Ja.isArray = Bf, Ja.isBoolean = function(a) {
            return !0 === a || !1 === a || n(a) && be.call(a) == Q
        }, Ja.isDate = function(a) {
            return n(a) && be.call(a) == R
        }, Ja.isElement = function(a) {
            return !!a && 1 === a.nodeType && n(a) && !sd(a)
        }, Ja.isEmpty = function(a) {
            return null == a ? !0 : Cc(a) && (Bf(a) || ud(a) || ld(a) || n(a) && od(a.splice)) ? !a.length : !Mf(a).length
        }, Ja.isEqual = md, Ja.isError = nd, Ja.isFinite = function(a) {
            return "number" == typeof a && se(a)
        }, Ja.isFunction = od, Ja.isMatch = function(a, b, c, d) {
            return c = "function" == typeof c ? Nb(c, d, 3) : u, sb(a, wc(b), c)
        }, Ja.isNaN = function(a) {
            return rd(a) && a != +a
        }, Ja.isNative = qd, Ja.isNull = function(a) {
            return null === a
        }, Ja.isNumber = rd, Ja.isObject = pd, Ja.isPlainObject = sd, Ja.isRegExp = td, Ja.isString = ud, Ja.isTypedArray = vd, Ja.isUndefined = function(a) {
            return a === u
        }, Ja.kebabCase = Sf, Ja.last = Uc, Ja.lastIndexOf = function(a, b, c) {
            var d = a ? a.length : 0;
            if (!d) return -1;
            var e = d;
            if ("number" == typeof c) e = (0 > c ? ue(d + c, 0) : ve(c || 0, d - 1)) + 1;
            else if (c) return e = Lb(a, b, !0) - 1, a = a[e], (b === b ? b === a : a !== a) ? e : -1;
            if (b !== b) return m(a, e, !0);
            for (; e--;)
                if (a[e] === b) return e;
            return -1
        }, Ja.lt = wd, Ja.lte = function(a, b) {
            return b >= a
        }, Ja.max = ag, Ja.min = bg, Ja.noConflict = function() {
            return Ua._ = ce, this
        }, Ja.noop = Ld, Ja.now = nf, Ja.pad = function(a, b, c) {
            a = e(a), b = +b;
            var d = a.length;
            return b > d && se(b) ? (d = (b - d) / 2, b = qe(d), d = oe(d), c = lc("", d, c), c.slice(0, b) + a + c) : a
        }, Ja.padLeft = Tf, Ja.padRight = Uf, Ja.parseInt = function(a, b, c) {
            return (c ? Ec(a, b, c) : null == b) ? b = 0 : b && (b = +b), a = Fd(a), xe(a, b || (za.test(a) ? 16 : 10))
        }, Ja.random = function(a, b, c) {
            c && Ec(a, b, c) && (b = c = u);
            var d = null == a,
                e = null == b;
            return null == c && (e && "boolean" == typeof a ? (c = a, a = 1) : "boolean" == typeof b && (c = b, e = !0)), d && e && (b = 1, e = !1), a = +a || 0, e ? (b = a, a = 0) : b = +b || 0, c || a % 1 || b % 1 ? (c = ye(), ve(a + c * (b - a + ge("1e-" + ((c + "").length - 1))), b)) : Ab(a, b)
        }, Ja.reduce = kf, Ja.reduceRight = lf, Ja.repeat = Ed, Ja.result = function(a, b, c) {
            var d = null == a ? u : a[b];
            return d === u && (null == a || Fc(b, a) || (b = Oc(b), a = 1 == b.length ? a : qb(a, Cb(b, 0, -1)), d = null == a ? u : a[Uc(b)]), d = d === u ? c : d), od(d) ? d.call(a) : d
        }, Ja.round = cg, Ja.runInContext = t, Ja.size = function(a) {
            var b = a ? Ne(a) : 0;
            return Hc(b) ? b : Mf(a).length
        }, Ja.snakeCase = Vf, Ja.some = fd, Ja.sortedIndex = Ue, Ja.sortedLastIndex = Ve, Ja.startCase = Wf, Ja.startsWith = function(a, b, c) {
            return a = e(a), c = null == c ? 0 : ve(0 > c ? 0 : +c || 0, a.length), a.lastIndexOf(b, c) == c
        }, Ja.sum = function(a, b, c) {
            if (c && Ec(a, b, c) && (b = u), b = tc(b, c, 3), 1 == b.length) {
                a = Bf(a) ? a : Mc(a), c = a.length;
                for (var d = 0; c--;) d += +b(a[c]) || 0;
                a = d
            } else a = Gb(a, b);
            return a
        }, Ja.template = function(a, b, c) {
            var d = Ja.templateSettings;
            c && Ec(a, b, c) && (b = c = u), a = e(a), b = _a(ab({}, c || b), d, $a), c = _a(ab({}, b.imports), d.imports, $a);
            var f, g, h = Mf(c),
                i = Ib(c, h),
                j = 0;
            c = b.interpolate || Da;
            var k = "__p+='";
            c = Ud((b.escape || Da).source + "|" + c.source + "|" + (c === pa ? xa : Da).source + "|" + (b.evaluate || Da).source + "|$", "g");
            var m = "sourceURL" in b ? "//# sourceURL=" + b.sourceURL + "\n" : "";
            if (a.replace(c, function(b, c, d, e, h, i) {
                    return d || (d = e), k += a.slice(j, i).replace(Ea, l), c && (f = !0, k += "'+__e(" + c + ")+'"), h && (g = !0, k += "';" + h + ";\n__p+='"), d && (k += "'+((__t=(" + d + "))==null?'':__t)+'"), j = i + b.length, b
                }), k += "';", (b = b.variable) || (k = "with(obj){" + k + "}"), k = (g ? k.replace(ga, "") : k).replace(ha, "$1").replace(ia, "$1;"), k = "function(" + (b || "obj") + "){" + (b ? "" : "obj||(obj={});") + "var __t,__p=''" + (f ? ",__e=_.escape" : "") + (g ? ",__j=Array.prototype.join;function print(){__p+=__j.call(arguments,'')}" : ";") + k + "return __p}", b = Xf(function() {
                    return Qd(h, m + "return " + k).apply(u, i)
                }), b.source = k, nd(b)) throw b;
            return b
        }, Ja.trim = Fd, Ja.trimLeft = function(a, b, c) {
            var d = a;
            return (a = e(a)) ? a.slice((c ? Ec(d, b, c) : null == b) ? q(a) : f(a, b + "")) : a
        }, Ja.trimRight = function(a, b, c) {
            var d = a;
            return (a = e(a)) ? (c ? Ec(d, b, c) : null == b) ? a.slice(0, r(a) + 1) : a.slice(0, g(a, b + "") + 1) : a
        }, Ja.trunc = function(a, b, c) {
            c && Ec(a, b, c) && (b = u);
            var d = F;
            if (c = G, null != b)
                if (pd(b)) {
                    var f = "separator" in b ? b.separator : f,
                        d = "length" in b ? +b.length || 0 : d;
                    c = "omission" in b ? e(b.omission) : c
                } else d = +b || 0;
            if (a = e(a), d >= a.length) return a;
            if (d -= c.length, 1 > d) return c;
            if (b = a.slice(0, d), null == f) return b + c;
            if (td(f)) {
                if (a.slice(d).search(f)) {
                    var g, h = a.slice(0, d);
                    for (f.global || (f = Ud(f.source, (ya.exec(f) || "") + "g")), f.lastIndex = 0; a = f.exec(h);) g = a.index;
                    b = b.slice(0, null == g ? d : g)
                }
            } else a.indexOf(f, d) != d && (f = b.lastIndexOf(f), f > -1 && (b = b.slice(0, f)));
            return b + c
        }, Ja.unescape = function(a) {
            return (a = e(a)) && la.test(a) ? a.replace(ja, s) : a
        }, Ja.uniqueId = function(a) {
            var b = ++ae;
            return e(a) + b
        }, Ja.words = Gd, Ja.all = ad, Ja.any = fd, Ja.contains = cd, Ja.eq = md, Ja.detect = bf, Ja.foldl = kf, Ja.foldr = lf, Ja.head = Sc, Ja.include = cd, Ja.inject = kf, Kd(Ja, function() {
            var a = {};
            return nb(Ja, function(b, c) {
                Ja.prototype[c] || (a[c] = b)
            }), a
        }(), !1), Ja.sample = ed, Ja.prototype.sample = function(a) {
            return this.__chain__ || null != a ? this.thru(function(b) {
                return ed(b, a)
            }) : ed(this.value())
        }, Ja.VERSION = v, Ra("bind bindKey curry curryRight partial partialRight".split(" "), function(a) {
            Ja[a].placeholder = Ja
        }), Ra(["drop", "take"], function(a, b) {
            Ma.prototype[a] = function(c) {
                var d = this.__filtered__;
                if (d && !b) return new Ma(this);
                c = null == c ? 1 : ue(qe(c) || 0, 0);
                var e = this.clone();
                return d ? e.__takeCount__ = ve(e.__takeCount__, c) : e.__views__.push({
                    size: c,
                    type: a + (0 > e.__dir__ ? "Right" : "")
                }), e
            }, Ma.prototype[a + "Right"] = function(b) {
                return this.reverse()[a](b).reverse()
            }
        }), Ra(["filter", "map", "takeWhile"], function(a, b) {
            var c = b + 1,
                d = c != L;
            Ma.prototype[a] = function(a, b) {
                var e = this.clone();
                return e.__iteratees__.push({
                    iteratee: tc(a, b, 1),
                    type: c
                }), e.__filtered__ = e.__filtered__ || d, e
            }
        }), Ra(["first", "last"], function(a, b) {
            var c = "take" + (b ? "Right" : "");
            Ma.prototype[a] = function() {
                return this[c](1).value()[0]
            }
        }), Ra(["initial", "rest"], function(a, b) {
            var c = "drop" + (b ? "" : "Right");
            Ma.prototype[a] = function() {
                return this.__filtered__ ? new Ma(this) : this[c](1)
            }
        }), Ra(["pluck", "where"], function(a, b) {
            var c = b ? "filter" : "map",
                d = b ? ub : Md;
            Ma.prototype[a] = function(a) {
                return this[c](d(a))
            }
        }), Ma.prototype.compact = function() {
            return this.filter(Id)
        }, Ma.prototype.reject = function(a, b) {
            return a = tc(a, b, 1), this.filter(function(b) {
                return !a(b)
            })
        }, Ma.prototype.slice = function(a, b) {
            a = null == a ? 0 : +a || 0;
            var c = this;
            return c.__filtered__ && (a > 0 || 0 > b) ? new Ma(c) : (0 > a ? c = c.takeRight(-a) : a && (c = c.drop(a)), b !== u && (b = +b || 0, c = 0 > b ? c.dropRight(-b) : c.take(b - a)), c)
        }, Ma.prototype.takeRightWhile = function(a, b) {
            return this.reverse().takeWhile(a, b).reverse()
        }, Ma.prototype.toArray = function() {
            return this.take(Ae)
        }, nb(Ma.prototype, function(a, b) {
            var c = /^(?:filter|map|reject)|While$/.test(b),
                d = /^(?:first|last)$/.test(b),
                e = Ja[d ? "take" + ("last" == b ? "Right" : "") : b];
            e && (Ja.prototype[b] = function() {
                function b(a) {
                    return d && g ? e(a, 1)[0] : e.apply(u, Xa([a], f))
                }
                var f = d ? [1] : arguments,
                    g = this.__chain__,
                    h = this.__wrapped__,
                    i = !!this.__actions__.length,
                    j = h instanceof Ma,
                    k = f[0],
                    l = j || Bf(h);
                return l && c && "function" == typeof k && 1 != k.length && (j = l = !1), k = {
                    func: _c,
                    args: [b],
                    thisArg: u
                }, i = j && !i, d && !g ? i ? (h = h.clone(), h.__actions__.push(k), a.call(h)) : e.call(u, this.value())[0] : !d && l ? (h = i ? h : new Ma(this), h = a.apply(h, f), h.__actions__.push(k), new La(h, g)) : this.thru(b)
            })
        }), Ra("join pop push replace shift sort splice split unshift".split(" "), function(a) {
            var b = (/^(?:replace|split)$/.test(a) ? Zd : Xd)[a],
                c = /^(?:push|sort|unshift)$/.test(a) ? "tap" : "thru",
                d = /^(?:join|pop|replace|shift)$/.test(a);
            Ja.prototype[a] = function() {
                var a = arguments;
                return d && !this.__chain__ ? b.apply(this.value(), a) : this[c](function(c) {
                    return b.apply(c, a)
                })
            }
        }), nb(Ma.prototype, function(a, b) {
            var c = Ja[b];
            if (c) {
                var d = c.name + "";
                (Fe[d] || (Fe[d] = [])).push({
                    name: b,
                    func: c
                })
            }
        }), Fe[kc(u, x).name] = [{
            name: "wrapper",
            func: u
        }], Ma.prototype.clone = function() {
            var a = new Ma(this.__wrapped__);
            return a.__actions__ = Qa(this.__actions__), a.__dir__ = this.__dir__, a.__filtered__ = this.__filtered__, a.__iteratees__ = Qa(this.__iteratees__), a.__takeCount__ = this.__takeCount__, a.__views__ = Qa(this.__views__), a
        }, Ma.prototype.reverse = function() {
            if (this.__filtered__) {
                var a = new Ma(this);
                a.__dir__ = -1, a.__filtered__ = !0
            } else a = this.clone(), a.__dir__ *= -1;
            return a
        }, Ma.prototype.value = function() {
            var a, b = this.__wrapped__.value(),
                c = this.__dir__,
                d = Bf(b),
                e = 0 > c,
                f = d ? b.length : 0;
            a = f;
            for (var g = this.__views__, h = 0, i = -1, j = g.length; ++i < j;) {
                var k = g[i],
                    l = k.size;
                switch (k.type) {
                    case "drop":
                        h += l;
                        break;
                    case "dropRight":
                        a -= l;
                        break;
                    case "take":
                        a = ve(a, h + l);
                        break;
                    case "takeRight":
                        h = ue(h, a - l)
                }
            }
            if (a = {
                    start: h,
                    end: a
                }, g = a.start, h = a.end, a = h - g, e = e ? h : g - 1, g = this.__iteratees__, h = g.length, i = 0, j = ve(a, this.__takeCount__), !d || J > f || f == a && j == a) return Kb(b, this.__actions__);
            d = [];
            a: for (; a-- && j > i;) {
                for (e += c, f = -1, k = b[e]; ++f < h;) {
                    var m = g[f],
                        l = m.type,
                        m = m.iteratee(k);
                    if (l == L) k = m;
                    else if (!m) {
                        if (l == K) continue a;
                        break a
                    }
                }
                d[i++] = k
            }
            return d
        }, Ja.prototype.chain = function() {
            return $c(this)
        }, Ja.prototype.commit = function() {
            return new La(this.value(), this.__chain__)
        }, Ja.prototype.concat = $e, Ja.prototype.plant = function(a) {
            for (var b, c = this; c instanceof Ka;) {
                var d = Pc(c);
                b ? e.__wrapped__ = d : b = d;
                var e = d,
                    c = c.__wrapped__
            }
            return e.__wrapped__ = a, b
        }, Ja.prototype.reverse = function() {
            function a(a) {
                return a.reverse()
            }
            var b = this.__wrapped__;
            return b instanceof Ma ? (this.__actions__.length && (b = new Ma(this)), b = b.reverse(), b.__actions__.push({
                func: _c,
                args: [a],
                thisArg: u
            }), new La(b, this.__chain__)) : this.thru(a)
        }, Ja.prototype.toString = function() {
            return this.value() + ""
        }, Ja.prototype.run = Ja.prototype.toJSON = Ja.prototype.valueOf = Ja.prototype.value = function() {
            return Kb(this.__wrapped__, this.__actions__)
        }, Ja.prototype.collect = Ja.prototype.map, Ja.prototype.head = Ja.prototype.first, Ja.prototype.select = Ja.prototype.filter, Ja.prototype.tail = Ja.prototype.rest, Ja
    }
    var u, v = "3.10.1",
        w = 1,
        x = 2,
        y = 4,
        z = 8,
        A = 16,
        B = 32,
        C = 64,
        D = 128,
        E = 256,
        F = 30,
        G = "...",
        H = 150,
        I = 16,
        J = 200,
        K = 1,
        L = 2,
        M = "Expected a function",
        N = "__lodash_placeholder__",
        O = "[object Arguments]",
        P = "[object Array]",
        Q = "[object Boolean]",
        R = "[object Date]",
        S = "[object Error]",
        T = "[object Function]",
        U = "[object Number]",
        V = "[object Object]",
        W = "[object RegExp]",
        X = "[object String]",
        Y = "[object ArrayBuffer]",
        Z = "[object Float32Array]",
        $ = "[object Float64Array]",
        _ = "[object Int8Array]",
        aa = "[object Int16Array]",
        ba = "[object Int32Array]",
        ca = "[object Uint8Array]",
        da = "[object Uint8ClampedArray]",
        ea = "[object Uint16Array]",
        fa = "[object Uint32Array]",
        ga = /\b__p\+='';/g,
        ha = /\b(__p\+=)''\+/g,
        ia = /(__e\(.*?\)|\b__t\))\+'';/g,
        ja = /&(?:amp|lt|gt|quot|#39|#96);/g,
        ka = /[&<>"'`]/g,
        la = RegExp(ja.source),
        ma = RegExp(ka.source),
        na = /<%-([\s\S]+?)%>/g,
        oa = /<%([\s\S]+?)%>/g,
        pa = /<%=([\s\S]+?)%>/g,
        qa = /\.|\[(?:[^[\]]*|(["'])(?:(?!\1)[^\n\\]|\\.)*?\1)\]/,
        ra = /^\w*$/,
        sa = /[^.[\]]+|\[(?:(-?\d+(?:\.\d+)?)|(["'])((?:(?!\2)[^\n\\]|\\.)*?)\2)\]/g,
        ta = /^[:!,]|[\\^$.*+?()[\]{}|\/]|(^[0-9a-fA-Fnrtuvx])|([\n\r\u2028\u2029])/g,
        ua = RegExp(ta.source),
        va = /[\u0300-\u036f\ufe20-\ufe23]/g,
        wa = /\\(\\)?/g,
        xa = /\$\{([^\\}]*(?:\\.[^\\}]*)*)\}/g,
        ya = /\w*$/,
        za = /^0[xX]/,
        Aa = /^\[object .+?Constructor\]$/,
        Ba = /^\d+$/,
        Ca = /[\xc0-\xd6\xd8-\xde\xdf-\xf6\xf8-\xff]/g,
        Da = /($^)/,
        Ea = /['\n\r\u2028\u2029\\]/g,
        Fa = RegExp("[A-Z\\xc0-\\xd6\\xd8-\\xde]+(?=[A-Z\\xc0-\\xd6\\xd8-\\xde][a-z\\xdf-\\xf6\\xf8-\\xff]+)|[A-Z\\xc0-\\xd6\\xd8-\\xde]?[a-z\\xdf-\\xf6\\xf8-\\xff]+|[A-Z\\xc0-\\xd6\\xd8-\\xde]+|[0-9]+", "g"),
        Ga = "Array ArrayBuffer Date Error Float32Array Float64Array Function Int8Array Int16Array Int32Array Math Number Object RegExp Set String _ clearTimeout isFinite parseFloat parseInt setTimeout TypeError Uint8Array Uint8ClampedArray Uint16Array Uint32Array WeakMap".split(" "),
        Ha = {};
    Ha[Z] = Ha[$] = Ha[_] = Ha[aa] = Ha[ba] = Ha[ca] = Ha[da] = Ha[ea] = Ha[fa] = !0, Ha[O] = Ha[P] = Ha[Y] = Ha[Q] = Ha[R] = Ha[S] = Ha[T] = Ha["[object Map]"] = Ha[U] = Ha[V] = Ha[W] = Ha["[object Set]"] = Ha[X] = Ha["[object WeakMap]"] = !1;
    var Ia = {};
    Ia[O] = Ia[P] = Ia[Y] = Ia[Q] = Ia[R] = Ia[Z] = Ia[$] = Ia[_] = Ia[aa] = Ia[ba] = Ia[U] = Ia[V] = Ia[W] = Ia[X] = Ia[ca] = Ia[da] = Ia[ea] = Ia[fa] = !0, Ia[S] = Ia[T] = Ia["[object Map]"] = Ia["[object Set]"] = Ia["[object WeakMap]"] = !1;
    var Ja = {
            "À": "A",
            "Á": "A",
            "Â": "A",
            "Ã": "A",
            "Ä": "A",
            "Å": "A",
            "à": "a",
            "á": "a",
            "â": "a",
            "ã": "a",
            "ä": "a",
            "å": "a",
            "Ç": "C",
            "ç": "c",
            "Ð": "D",
            "ð": "d",
            "È": "E",
            "É": "E",
            "Ê": "E",
            "Ë": "E",
            "è": "e",
            "é": "e",
            "ê": "e",
            "ë": "e",
            "Ì": "I",
            "Í": "I",
            "Î": "I",
            "Ï": "I",
            "ì": "i",
            "í": "i",
            "î": "i",
            "ï": "i",
            "Ñ": "N",
            "ñ": "n",
            "Ò": "O",
            "Ó": "O",
            "Ô": "O",
            "Õ": "O",
            "Ö": "O",
            "Ø": "O",
            "ò": "o",
            "ó": "o",
            "ô": "o",
            "õ": "o",
            "ö": "o",
            "ø": "o",
            "Ù": "U",
            "Ú": "U",
            "Û": "U",
            "Ü": "U",
            "ù": "u",
            "ú": "u",
            "û": "u",
            "ü": "u",
            "Ý": "Y",
            "ý": "y",
            "ÿ": "y",
            "Æ": "Ae",
            "æ": "ae",
            "Þ": "Th",
            "þ": "th",
            "ß": "ss"
        },
        Ka = {
            "&": "&amp;",
            "<": "&lt;",
            ">": "&gt;",
            '"': "&quot;",
            "'": "&#39;",
            "`": "&#96;"
        },
        La = {
            "&amp;": "&",
            "&lt;": "<",
            "&gt;": ">",
            "&quot;": '"',
            "&#39;": "'",
            "&#96;": "`"
        },
        Ma = {
            "function": !0,
            object: !0
        },
        Na = {
            0: "x30",
            1: "x31",
            2: "x32",
            3: "x33",
            4: "x34",
            5: "x35",
            6: "x36",
            7: "x37",
            8: "x38",
            9: "x39",
            A: "x41",
            B: "x42",
            C: "x43",
            D: "x44",
            E: "x45",
            F: "x46",
            a: "x61",
            b: "x62",
            c: "x63",
            d: "x64",
            e: "x65",
            f: "x66",
            n: "x6e",
            r: "x72",
            t: "x74",
            u: "x75",
            v: "x76",
            x: "x78"
        },
        Oa = {
            "\\": "\\",
            "'": "'",
            "\n": "n",
            "\r": "r",
            "\u2028": "u2028",
            "\u2029": "u2029"
        },
        Pa = Ma[typeof exports] && exports && !exports.nodeType && exports,
        Qa = Ma[typeof module] && module && !module.nodeType && module,
        Ra = Ma[typeof self] && self && self.Object && self,
        Sa = Ma[typeof window] && window && window.Object && window,
        Ta = Qa && Qa.exports === Pa && Pa,
        Ua = Pa && Qa && "object" == typeof global && global && global.Object && global || Sa !== (this && this.window) && Sa || Ra || this,
        Va = t();
    "function" == typeof define && "object" == typeof define.amd && define.amd ? (Ua._ = Va, define(function() {
        return Va
    })) : Pa && Qa ? Ta ? (Qa.exports = Va)._ = Va : Pa._ = Va : Ua._ = Va
}.call(this),
    function() {
        (function() {
            "use strict";

            function a(a) {
                return "function" == typeof a || "object" == typeof a && null !== a
            }

            function b(a) {
                return "function" == typeof a
            }

            function c(a) {
                return "object" == typeof a && null !== a
            }

            function d() {}

            function e(a, b) {
                for (var c = 0, d = a.length; d > c; c++)
                    if (a[c] === b) return c;
                return -1
            }

            function f(a) {
                var b = a._promiseCallbacks;
                return b || (b = a._promiseCallbacks = {}), b
            }

            function g(a, b) {
                return "onerror" === a ? void va.on("error", b) : 2 !== arguments.length ? va[a] : void(va[a] = b)
            }

            function h() {
                setTimeout(function() {
                    for (var a, b = 0; b < wa.length; b++) {
                        a = wa[b];
                        var c = a.payload;
                        c.guid = c.key + c.id, c.childGuid = c.key + c.childId, c.error && (c.stack = c.error.stack), va.trigger(a.name, a.payload)
                    }
                    wa.length = 0
                }, 50)
            }

            function i(a, b, c) {
                1 === wa.push({
                    name: a,
                    payload: {
                        key: b._guidKey,
                        id: b._id,
                        eventName: a,
                        detail: b._result,
                        childId: c && c._id,
                        label: b._label,
                        timeStamp: sa(),
                        error: va["instrument-with-stack"] ? new Error(b._label) : null
                    }
                }) && h()
            }

            function j() {
                return new TypeError("A promises callback cannot return that same promise.")
            }

            function k() {}

            function l(a) {
                try {
                    return a.then
                } catch (b) {
                    return Ba.error = b, Ba
                }
            }

            function m(a, b, c, d) {
                try {
                    a.call(b, c, d)
                } catch (e) {
                    return e
                }
            }

            function n(a, b, c) {
                va.async(function(a) {
                    var d = !1,
                        e = m(c, b, function(c) {
                            d || (d = !0, b !== c ? q(a, c) : s(a, c))
                        }, function(b) {
                            d || (d = !0, t(a, b))
                        }, "Settle: " + (a._label || " unknown promise"));
                    !d && e && (d = !0, t(a, e))
                }, a)
            }

            function o(a, b) {
                b._state === za ? s(a, b._result) : b._state === Aa ? (b._onError = null, t(a, b._result)) : u(b, void 0, function(c) {
                    b !== c ? q(a, c) : s(a, c)
                }, function(b) {
                    t(a, b)
                })
            }

            function p(a, c) {
                if (c.constructor === a.constructor) o(a, c);
                else {
                    var d = l(c);
                    d === Ba ? t(a, Ba.error) : void 0 === d ? s(a, c) : b(d) ? n(a, c, d) : s(a, c)
                }
            }

            function q(b, c) {
                b === c ? s(b, c) : a(c) ? p(b, c) : s(b, c)
            }

            function r(a) {
                a._onError && a._onError(a._result), v(a)
            }

            function s(a, b) {
                a._state === ya && (a._result = b, a._state = za, 0 === a._subscribers.length ? va.instrument && xa("fulfilled", a) : va.async(v, a))
            }

            function t(a, b) {
                a._state === ya && (a._state = Aa, a._result = b, va.async(r, a))
            }

            function u(a, b, c, d) {
                var e = a._subscribers,
                    f = e.length;
                a._onError = null, e[f] = b, e[f + za] = c, e[f + Aa] = d, 0 === f && a._state && va.async(v, a)
            }

            function v(a) {
                var b = a._subscribers,
                    c = a._state;
                if (va.instrument && xa(c === za ? "fulfilled" : "rejected", a), 0 !== b.length) {
                    for (var d, e, f = a._result, g = 0; g < b.length; g += 3) d = b[g], e = b[g + c], d ? y(c, d, e, f) : e(f);
                    a._subscribers.length = 0
                }
            }

            function w() {
                this.error = null
            }

            function x(a, b) {
                try {
                    return a(b)
                } catch (c) {
                    return Ca.error = c, Ca
                }
            }

            function y(a, c, d, e) {
                var f, g, h, i, k = b(d);
                if (k) {
                    if (f = x(d, e), f === Ca ? (i = !0, g = f.error, f = null) : h = !0, c === f) return void t(c, j())
                } else f = e, h = !0;
                c._state !== ya || (k && h ? q(c, f) : i ? t(c, g) : a === za ? s(c, f) : a === Aa && t(c, f))
            }

            function z(a, b) {
                var c = !1;
                try {
                    b(function(b) {
                        c || (c = !0, q(a, b))
                    }, function(b) {
                        c || (c = !0, t(a, b))
                    })
                } catch (d) {
                    t(a, d)
                }
            }

            function A(a, b, c) {
                return a === za ? {
                    state: "fulfilled",
                    value: c
                } : {
                    state: "rejected",
                    reason: c
                }
            }

            function B(a, b, c, d) {
                this._instanceConstructor = a, this.promise = new a(k, d), this._abortOnReject = c, this._validateInput(b) ? (this._input = b, this.length = b.length, this._remaining = b.length, this._init(), 0 === this.length ? s(this.promise, this._result) : (this.length = this.length || 0, this._enumerate(), 0 === this._remaining && s(this.promise, this._result))) : t(this.promise, this._validationError())
            }

            function C(a, b) {
                return new Da(this, a, !0, b).promise
            }

            function D(a, b) {
                function c(a) {
                    q(f, a)
                }

                function d(a) {
                    t(f, a)
                }
                var e = this,
                    f = new e(k, b);
                if (!ra(a)) return t(f, new TypeError("You must pass an array to race.")), f;
                for (var g = a.length, h = 0; f._state === ya && g > h; h++) u(e.resolve(a[h]), void 0, c, d);
                return f
            }

            function E(a, b) {
                var c = this;
                if (a && "object" == typeof a && a.constructor === c) return a;
                var d = new c(k, b);
                return q(d, a), d
            }

            function F(a, b) {
                var c = this,
                    d = new c(k, b);
                return t(d, a), d
            }

            function G() {
                throw new TypeError("You must pass a resolver function as the first argument to the promise constructor")
            }

            function H() {
                throw new TypeError("Failed to construct 'Promise': Please use the 'new' operator, this object constructor cannot be called as a function.")
            }

            function I(a, c) {
                this._id = Ja++, this._label = c, this._state = void 0, this._result = void 0, this._subscribers = [], va.instrument && xa("created", this), k !== a && (b(a) || G(), this instanceof I || H(), z(this, a))
            }

            function J(a, b, c) {
                this._superConstructor(a, b, !1, c)
            }

            function K(a, b) {
                return new J(Ka, a, b).promise
            }

            function L(a, b) {
                return Ka.all(a, b)
            }

            function M(a, b) {
                Wa[Pa] = a, Wa[Pa + 1] = b, Pa += 2, 2 === Pa && Ma()
            }

            function N() {
                var a = process.nextTick,
                    b = process.versions.node.match(/^(?:(\d+)\.)?(?:(\d+)\.)?(\*|\d+)$/);
                return Array.isArray(b) && "0" === b[1] && "10" === b[2] && (a = setImmediate),
                    function() {
                        a(S)
                    }
            }

            function O() {
                return function() {
                    La(S)
                }
            }

            function P() {
                var a = 0,
                    b = new Ta(S),
                    c = document.createTextNode("");
                return b.observe(c, {
                        characterData: !0
                    }),
                    function() {
                        c.data = a = ++a % 2
                    }
            }

            function Q() {
                var a = new MessageChannel;
                return a.port1.onmessage = S,
                    function() {
                        a.port2.postMessage(0)
                    }
            }

            function R() {
                return function() {
                    setTimeout(S, 1)
                }
            }

            function S() {
                for (var a = 0; Pa > a; a += 2) {
                    var b = Wa[a],
                        c = Wa[a + 1];
                    b(c), Wa[a] = void 0, Wa[a + 1] = void 0
                }
                Pa = 0
            }

            function T() {
                try {
                    var a = require,
                        b = a("vertx");
                    return La = b.runOnLoop || b.runOnContext, O()
                } catch (c) {
                    return R()
                }
            }

            function U(a) {
                var b = {};
                return b.promise = new Ka(function(a, c) {
                    b.resolve = a, b.reject = c
                }, a), b
            }

            function V(a, c, d) {
                return Ka.all(a, d).then(function(a) {
                    if (!b(c)) throw new TypeError("You must pass a function as filter's second argument.");
                    for (var e = a.length, f = new Array(e), g = 0; e > g; g++) f[g] = c(a[g]);
                    return Ka.all(f, d).then(function(b) {
                        for (var c = new Array(e), d = 0, f = 0; e > f; f++) b[f] && (c[d] = a[f], d++);
                        return c.length = d, c
                    })
                })
            }

            function W(a, b, c) {
                this._superConstructor(a, b, !0, c)
            }

            function X(a, b, c) {
                this._superConstructor(a, b, !1, c)
            }

            function Y(a, b) {
                return new X(Ka, a, b).promise
            }

            function Z(a, b) {
                return new Za(Ka, a, b).promise
            }

            function $(a, c, d) {
                return Ka.all(a, d).then(function(a) {
                    if (!b(c)) throw new TypeError("You must pass a function as map's second argument.");
                    for (var e = a.length, f = new Array(e), g = 0; e > g; g++) f[g] = c(a[g]);
                    return Ka.all(f, d)
                })
            }

            function _() {
                this.value = void 0
            }

            function aa(a) {
                try {
                    return a.then
                } catch (b) {
                    return bb.value = b, bb
                }
            }

            function ba(a, b, c) {
                try {
                    a.apply(b, c)
                } catch (d) {
                    return bb.value = d, bb
                }
            }

            function ca(a, b) {
                for (var c, d, e = {}, f = a.length, g = new Array(f), h = 0; f > h; h++) g[h] = a[h];
                for (d = 0; d < b.length; d++) c = b[d], e[c] = g[d + 1];
                return e
            }

            function da(a) {
                for (var b = a.length, c = new Array(b - 1), d = 1; b > d; d++) c[d - 1] = a[d];
                return c
            }

            function ea(a, b) {
                return {
                    then: function(c, d) {
                        return a.call(b, c, d)
                    }
                }
            }

            function fa(a, b) {
                var c = function() {
                    for (var c, d = this, e = arguments.length, f = new Array(e + 1), g = !1, h = 0; e > h; ++h) {
                        if (c = arguments[h], !g) {
                            if (g = ia(c), g === cb) {
                                var i = new Ka(k);
                                return t(i, cb.value), i
                            }
                            g && g !== !0 && (c = ea(g, c))
                        }
                        f[h] = c
                    }
                    var j = new Ka(k);
                    return f[e] = function(a, c) {
                        a ? t(j, a) : void 0 === b ? q(j, c) : b === !0 ? q(j, da(arguments)) : ra(b) ? q(j, ca(arguments, b)) : q(j, c)
                    }, g ? ha(j, f, a, d) : ga(j, f, a, d)
                };
                return c.__proto__ = a, c
            }

            function ga(a, b, c, d) {
                var e = ba(c, d, b);
                return e === bb && t(a, e.value), a
            }

            function ha(a, b, c, d) {
                return Ka.all(b).then(function(b) {
                    var e = ba(c, d, b);
                    return e === bb && t(a, e.value), a
                })
            }

            function ia(a) {
                return a && "object" == typeof a ? a.constructor === Ka ? !0 : aa(a) : !1
            }

            function ja(a, b) {
                return Ka.race(a, b)
            }

            function ka(a, b) {
                return Ka.reject(a, b)
            }

            function la(a, b) {
                return Ka.resolve(a, b)
            }

            function ma(a) {
                throw setTimeout(function() {
                    throw a
                }), a
            }

            function na(a, b) {
                va.async(a, b)
            }

            function oa() {
                va.on.apply(va, arguments)
            }

            function pa() {
                va.off.apply(va, arguments)
            }
            var qa;
            qa = Array.isArray ? Array.isArray : function(a) {
                return "[object Array]" === Object.prototype.toString.call(a)
            };
            var ra = qa,
                sa = Date.now || function() {
                    return (new Date).getTime()
                },
                ta = Object.create || function(a) {
                    if (arguments.length > 1) throw new Error("Second argument not supported");
                    if ("object" != typeof a) throw new TypeError("Argument must be an object");
                    return d.prototype = a, new d
                },
                ua = {
                    mixin: function(a) {
                        return a.on = this.on, a.off = this.off, a.trigger = this.trigger, a._promiseCallbacks = void 0, a
                    },
                    on: function(a, b) {
                        var c, d = f(this);
                        c = d[a], c || (c = d[a] = []), -1 === e(c, b) && c.push(b)
                    },
                    off: function(a, b) {
                        var c, d, g = f(this);
                        return b ? (c = g[a], d = e(c, b), void(-1 !== d && c.splice(d, 1))) : void(g[a] = [])
                    },
                    trigger: function(a, b) {
                        var c, d, e = f(this);
                        if (c = e[a])
                            for (var g = 0; g < c.length; g++)(d = c[g])(b)
                    }
                },
                va = {
                    instrument: !1
                };
            ua.mixin(va);
            var wa = [],
                xa = i,
                ya = void 0,
                za = 1,
                Aa = 2,
                Ba = new w,
                Ca = new w,
                Da = B;
            B.prototype._validateInput = function(a) {
                return ra(a)
            }, B.prototype._validationError = function() {
                return new Error("Array Methods must be provided an Array")
            }, B.prototype._init = function() {
                this._result = new Array(this.length)
            }, B.prototype._enumerate = function() {
                for (var a = this.length, b = this.promise, c = this._input, d = 0; b._state === ya && a > d; d++) this._eachEntry(c[d], d)
            }, B.prototype._eachEntry = function(a, b) {
                var d = this._instanceConstructor;
                c(a) ? a.constructor === d && a._state !== ya ? (a._onError = null, this._settledAt(a._state, b, a._result)) : this._willSettleAt(d.resolve(a), b) : (this._remaining--, this._result[b] = this._makeResult(za, b, a))
            }, B.prototype._settledAt = function(a, b, c) {
                var d = this.promise;
                d._state === ya && (this._remaining--, this._abortOnReject && a === Aa ? t(d, c) : this._result[b] = this._makeResult(a, b, c)), 0 === this._remaining && s(d, this._result)
            }, B.prototype._makeResult = function(a, b, c) {
                return c
            }, B.prototype._willSettleAt = function(a, b) {
                var c = this;
                u(a, void 0, function(a) {
                    c._settledAt(za, b, a)
                }, function(a) {
                    c._settledAt(Aa, b, a)
                })
            };
            var Ea = C,
                Fa = D,
                Ga = E,
                Ha = F,
                Ia = "rsvp_" + sa() + "-",
                Ja = 0,
                Ka = I;
            I.cast = Ga, I.all = Ea, I.race = Fa, I.resolve = Ga, I.reject = Ha, I.prototype = {
                constructor: I,
                _guidKey: Ia,
                _onError: function(a) {
                    va.async(function(b) {
                        setTimeout(function() {
                            b._onError && va.trigger("error", a)
                        }, 0)
                    }, this)
                },
                then: function(a, b, c) {
                    var d = this,
                        e = d._state;
                    if (e === za && !a || e === Aa && !b) return va.instrument && xa("chained", this, this), this;
                    d._onError = null;
                    var f = new this.constructor(k, c),
                        g = d._result;
                    if (va.instrument && xa("chained", d, f), e) {
                        var h = arguments[e - 1];
                        va.async(function() {
                            y(e, f, h, g)
                        })
                    } else u(d, f, a, b);
                    return f
                },
                "catch": function(a, b) {
                    return this.then(null, a, b)
                },
                "finally": function(a, b) {
                    var c = this.constructor;
                    return this.then(function(b) {
                        return c.resolve(a()).then(function() {
                            return b
                        })
                    }, function(b) {
                        return c.resolve(a()).then(function() {
                            throw b
                        })
                    }, b)
                }
            }, J.prototype = ta(Da.prototype), J.prototype._superConstructor = Da, J.prototype._makeResult = A, J.prototype._validationError = function() {
                return new Error("allSettled must be called with an array")
            };
            var La, Ma, Na = K,
                Oa = L,
                Pa = 0,
                Qa = ({}.toString, M),
                Ra = "undefined" != typeof window ? window : void 0,
                Sa = Ra || {},
                Ta = Sa.MutationObserver || Sa.WebKitMutationObserver,
                Ua = "undefined" != typeof process && "[object process]" === {}.toString.call(process),
                Va = "undefined" != typeof Uint8ClampedArray && "undefined" != typeof importScripts && "undefined" != typeof MessageChannel,
                Wa = new Array(1e3);
            Ma = Ua ? N() : Ta ? P() : Va ? Q() : void 0 === Ra && "function" == typeof require ? T() : R();
            var Xa = U,
                Ya = V,
                Za = W;
            W.prototype = ta(Da.prototype), W.prototype._superConstructor = Da, W.prototype._init = function() {
                this._result = {}
            }, W.prototype._validateInput = function(a) {
                return a && "object" == typeof a
            }, W.prototype._validationError = function() {
                return new Error("Promise.hash must be called with an object")
            }, W.prototype._enumerate = function() {
                var a = this.promise,
                    b = this._input,
                    c = [];
                for (var d in b) a._state === ya && Object.prototype.hasOwnProperty.call(b, d) && c.push({
                    position: d,
                    entry: b[d]
                });
                var e = c.length;
                this._remaining = e;
                for (var f, g = 0; a._state === ya && e > g; g++) f = c[g], this._eachEntry(f.entry, f.position)
            }, X.prototype = ta(Za.prototype), X.prototype._superConstructor = Da, X.prototype._makeResult = A, X.prototype._validationError = function() {
                return new Error("hashSettled must be called with an object")
            };
            var $a = Y,
                _a = Z,
                ab = $,
                bb = new _,
                cb = new _,
                db = fa,
                eb = ja,
                fb = ka,
                gb = la,
                hb = ma;
            va.async = Qa;
            if ("undefined" != typeof window && "object" == typeof window.__PROMISE_INSTRUMENTATION__) {
                var ib = window.__PROMISE_INSTRUMENTATION__;
                g("instrument", !0);
                for (var jb in ib) ib.hasOwnProperty(jb) && oa(jb, ib[jb])
            }
            var kb = {
                race: eb,
                Promise: Ka,
                allSettled: Na,
                hash: _a,
                hashSettled: $a,
                denodeify: db,
                on: oa,
                off: pa,
                map: ab,
                filter: Ya,
                resolve: gb,
                reject: fb,
                all: Oa,
                rethrow: hb,
                defer: Xa,
                EventTarget: ua,
                configure: g,
                async: na
            };
            "function" == typeof define && define.amd ? define(function() {
                return kb
            }) : "undefined" != typeof module && module.exports ? module.exports = kb : "undefined" != typeof this && (this.RSVP = kb)
        }).call(this),
            function(a) {
                function b(a) {
                    return this instanceof arguments.callee == !1 ? new b(a) : (this.name = a, this)
                }

                function c(a) {
                    for (var b in a) a.hasOwnProperty(b) && (this[b] = a[b]);
                    return this
                }
                b.prototype.oldSP = window.SP, Function.prototype.memoized = function(b) {
                    return this._values = this._values || {}, this._values[b] !== a ? this._values[b] : this._values[b] = this.apply(this, arguments)
                }, Function.prototype.memoize = function() {
                    var a = {},
                        b = this,
                        c = function() {
                            for (var c = [], d = 0; d < arguments.length; d++) c[d] = arguments[d];
                            return c in a || (a[c] = b.apply(this, arguments)), a[c]
                        };
                    return c
                }, b.prototype.__namespace = !0, b.prototype.namespace = function(a) {
                    return this[a] || (this[a] = new b((this.name ? this.name + "." : "") + a))
                }, b.prototype.extend = c, b.prototype.toString = function() {
                    return this.name
                }, b.prototype.namespace.call(this, "Ericsson").extend(function() {
                    function a(a) {
                        return void 0 === a || null === a ? String(a) : b[Object.prototype.toString.call(a)] || "object"
                    }
                    for (var b = {}, c = "Boolean Number String Function Array Date RegExp Object".split(" "), d = 0, e = c.length; e > d; d++) b["[object " + c[d] + "]"] = c[d].toLowerCase();
                    return {
                        type: a
                    }
                }()), SP = Ericsson
            }(), Ericsson.extend(function() {
                function a() {
                    var a, b, c, d, e, f = window.location.host,
                        g = "",
                        h = !0,
                        i = !1;
                    if (window.Xrm && Xrm.Page && Xrm.Page.context) {
                        if (d = Xrm.Page.context, d.getClientUrl) return Xrm.Page.context.getClientUrl();
                        d.getServerUrl && (g = Xrm.Page.context.getServerUrl())
                    } else window.GetGlobalContext ? (d = window.GetGlobalContext(), d.getClientUrl ? g = Xrm.Page.context.getClientUrl() : d.getServerUrl && (g = Xrm.Page.context.getServerUrl())) : (a = unescape(window.location.href).toLowerCase(), -1 !== a.indexOf("/webresources") && (c = a.split("/webresources")[0], g = c.match(p)[0], h = !1));
                    return g ? (e = null !== window.location.protocol.match(r), i = -1 === g.indexOf(window.location.protocol), h && !e && (b = g.match(o)[1], g = g.replace(b, f)), i && !e && (g = window.location.protocol + g.substring(g.indexOf(":") + 1)), g.match(q) && (g = g.substring(0, g.length - 1)), g) : void alert("Unable to determine server url using Ericsson.getServerUrl.  Please include ClientGlobalContext.js.aspx.")
                }

                function b() {
                    return Ericsson.Log.warn(["Deprecation warning. 'Ericsson.getServerUrl' has been deprecated and will be removed in the next major release. ", "Please be sure to migrate existing code to use the new 'Ericsson.getClientUrl' function."].join("")), a()
                }

                function c() {
                    var b, c = null;
                    return window.Xrm && Xrm.Page && Xrm.Page.context ? c = Xrm.Page.context.getOrgUniqueName() : window.GetGlobalContext && (c = GetGlobalContext().getOrgUniqueName()), c ? (b = a().replace(c, ""), b.match(q) || (b += "//"), b) : void alert("Unable to determine the organization name using Ericsson.getServerUrlWithoutOrg.  Please include ClientGlobalContext.js.aspx.")
                }

                function d() {
                    return Ericsson.Log.warn(["Deprecation warning. 'Ericsson.getServerUrlWithoutOrg' has been deprecated and will be removed in the next major release. ", "Please be sure to migrate existing code to use the new 'Ericsson.getClientUrlWithoutOrg' function."].join("")), c()
                }

                function e() {
                    var a, b = this;
                    this.length = 0, a = ["addOnChange", "fireOnChange", "getAttributeType", "getFormat", "getInitialValue", "getIsDirty", "getMax", "getMaxLength", "getMin", "getName", "getOption", "getParent", "getPrecision", "getRequiredLevel", "getSelectedOption", "getSubmitMode", "getText", "getUserPrivilege", "getValue", "removeOnChange", "setRequiredLevel", "setSubmitMode", "setValue"], k(a, function(a, c) {
                        b[c] = function() {
                            for (var a = arguments, d = null, e = 0; e < this.length; e++) {
                                var f = this[e],
                                    g = f[c].apply(f, a);
                                g && null === d && (d = g)
                            }
                            return d || b
                        }
                    })
                }

                function f(a) {
                    var b = new e;
                    return "array" !== Ericsson.type(a) && (a = Array.prototype.slice(arguments, 0)), k(a, function(a, c) {
                        var d = m(c);
                        d && ("array" !== Ericsson.type(d) && (d = [d]), k(d, function() {
                            Array.prototype.push.call(b, this)
                        }))
                    }), b
                }

                function g() {
                    var a, b = this;
                    this.length = 0, a = ["addCustomView", "addOption", "clearOptions", "getAttribute", "getControlType", "getData", "getDefaultView", "getDisabled", "getLabel", "getName", "getParent", "getSrc", "getInitialUrl", "getObject", "getVisible", "refresh", "removeOption", "setData", "setDefaultView", "setDisabled", "setFocus", "setLabel", "setSrc", "setVisible"], k(a, function(a, c) {
                        b[c] = function() {
                            for (var a = arguments, d = null, e = 0; e < this.length; e++) {
                                var f = this[e];
                                if (f[c]) {
                                    var g = f[c].apply(f, a);
                                    g && null === d && (d = g)
                                }
                            }
                            return d || b
                        }
                    })
                }

                function h(a) {
                    var b = new g;
                    return "array" !== Ericsson.type(a) && (a = Array.prototype.slice.call(arguments, 0)), k(a, function(a, c) {
                        var d = n(c);
                        d && ("array" !== Ericsson.type(d) && (d = [d]), k(d, function() {
                            Array.prototype.push.call(b, this)
                        }))
                    }), b
                }

                function i() {
                    var a, b = Array.prototype.slice.call(arguments, 0);
                    return 0 === b.length ? !0 : (a = b[0], k(b, function(b, c) {
                        var d = c === a;
                        return a = c, d
                    }))
                }

                function j(a) {
                    for (var b, c, d = (a || window.location.search || "").replace(/^\?/, ""), e = {}, f = d.split("&"), g = f.length; g--;) b = f[g].split("="), 2 === b.length && (c = unescape(b[1]), /&(.+?)=/.test(c) && (c = j(c)), e[b[0].toLowerCase()] = c);
                    return e
                }

                function k(a, b) {
                    var c, d;
                    if ("function" === Ericsson.type(b)) switch (Ericsson.type(a)) {
                        case "array":
                            for (c = 0; c < a.length; c++)
                                if (b.call(a[c], c, a[c]) === !1) return !1;
                            return !0;
                        case "object":
                            for (d in a)
                                if (a.hasOwnProperty(d) && b.call(a[d], d, a[d]) === !1) return !1;
                            return !0;
                        default:
                            throw new Error("Ericsson.each does not support the object " + a.toString())
                    }
                }

                function l() {
                    window.SP = Ericsson.oldSP
                }
                var m, n, o = /^(?:http)(?:s)?\:\/\/([^\/]+)/i,
                    p = /[^{]*/,
                    q = /\/$/,
                    r = /^about:/;
                return m = function(a) {
                    if (window.Xrm && Xrm.Page && Xrm.Page.getAttribute) return Xrm.Page.getAttribute(a);
                    throw new Error("Cannot use getAttribute: Xrm.Page.getAttribute is not available.")
                }.memoize(), n = function(a) {
                    if (window.Xrm && Xrm.Page && Xrm.Page.getControl) return Xrm.Page.getControl(a);
                    throw "Cannot use getControl: Xrm.Page.getControl is not available."
                }.memoize(), {
                    areEqual: i,
                    each: k,
                    getClientUrl: a,
                    getServerUrl: b,
                    getServerUrlWithoutOrg: d,
                    noConflict: l,
                    getQueryStringParams: j,
                    getAttribute: f,
                    getControl: h,
                    version: "@VERSION@"
                }
            }()), Ericsson.namespace("Form").extend({
                onSaveMode: {
                    Save: 1,
                    SaveAndClose: 2,
                    SaveAndNew: 59,
                    SaveAsCompleted: 58,
                    Deactivate: 5,
                    Reactivate: 6,
                    Assign: 47,
                    Send: 7,
                    Qualify: 16,
                    Disqualify: 15
                }
            }), Ericsson.namespace("Metadata").extend({
                entityFilters: {
                    All: 15,
                    Attributes: 3,
                    Default: 1,
                    Entity: 1,
                    Privileges: 5,
                    Relationships: 9
                }
            }), Ericsson.namespace("OrgService").extend({
                attributeTypes: {
                    Money: "Money",
                    OptionSetValue: "OptionSetValue",
                    Boolean: "Boolean",
                    EntityReference: "EntityReference",
                    DateTime: "DateTime",
                    Decimal: "Decimal",
                    Guid: "Guid"
                }
            }), Ericsson.namespace("Array").extend(function() {
                function a(a, c, d) {
                    var e, f;
                    if (!a || !b(a)) return -1;
                    if (Array.prototype.indexOf) return Array.prototype.indexOf.call(a, c, d);
                    for (e = (d || 0) - 1, f = a.length; ++e < f;)
                        if (a[e] === c) return e;
                    return -1
                }

                function b(a) {
                    return Array.isArray ? Array.isArray(a) : "[object Array]" === Object.prototype.toString.call(a)
                }
                return {
                    indexOf: a,
                    isArray: b
                }
            }()), Ericsson.namespace("String").extend(function() {
                function a(a) {
                    var b, c, d, e = 0,
                        f = [];
                    if (!a) return "";
                    if (f = Array.prototype.slice.call(arguments, 1), c = a.match(/\{\d+\}/g))
                        for (b = c.length; b > e; e++) d = parseInt(c[e].match(/\d+/), 10), f.length > d && (a = a.replace(c[e], f[d]));
                    return a
                }

                function b(a) {
                    return a.replace(g, "")
                }

                function c() {
                    var a = Array.prototype.slice.call(arguments, 0);
                    return a.join("")
                }

                function d(a) {
                    return "" === a || void 0 === a || null === a || "string" != typeof a
                }

                function e(a, b, c) {
                    for (var d = []; c-- > 0;) d.push(b);
                    return d.push(a), d.join("")
                }

                function f(a, b, c) {
                    for (var d = [a]; c-- > 0;) d.push(b);
                    return d.join("")
                }
                var g = /^\s+|\s+$/g;
                return {
                    format: a,
                    trim: b,
                    concat: c,
                    isNullOrEmpty: d,
                    padLeft: e,
                    padRight: f
                }
            }()), Ericsson.namespace("Date").extend(function() {
                function a(a, b) {
                    var c, d, e, f, g, h, j = a.toString();
                    return j = b.replace(/yyyy/g, a.getFullYear()), j = j.replace(/yy/g, (a.getFullYear() + "").substring(2)), c = a.getMonth(), j = j.replace(/MM/g, 10 > c + 1 ? "0" + (c + 1) : c + 1), j = j.replace(/(\\)?M/g, function(a, b) {
                        return b ? a : c + 1
                    }), d = a.getDate(), j = j.replace(/dd/g, 10 > d ? "0" + d : d), j = j.replace(/(\\)?d/g, function(a, b) {
                        return b ? a : d
                    }), e = a.getHours(), f = e > 12 ? e - 12 : e, j = j.replace(/HH/g, 10 > e ? "0" + e : e), j = j.replace(/(\\)?H/g, function(a, b) {
                        return b ? a : e
                    }), j = j.replace(/hh/g, 10 > e ? "0" + f : f), j = j.replace(/(\\)?h/g, function(a, b) {
                        return b ? a : f
                    }), g = a.getMinutes(), j = j.replace(/mm/g, 10 > g ? "0" + g : g), j = j.replace(/(\\)?m/g, function(a, b) {
                        return b ? a : g
                    }), h = a.getSeconds(), j = j.replace(/ss/g, 10 > h ? "0" + h : h), j = j.replace(/(\\)?s/g, function(a, b) {
                        return b ? a : h
                    }), j = j.replace(/fff/g, a.getMilliseconds()), j = j.replace(/tt/g, a.getHours() >= 12 ? i.PMDesignator : i.AMDesignator), j.replace(/\\/g, "")
                }

                function b(a) {
                    var b, c, d, e, f, g, h, i, k, l, m, n = Date.parse(a),
                        o = 0;
                    return b = j.exec(a), isNaN(n) && b && (c = parseInt(b[1], 10) || 0, d = (parseInt(b[2], 10) || 0) - 1, e = parseInt(b[3], 10) || 0, f = parseInt(b[4], 10) || 0, g = parseInt(b[5], 10) || 0, h = parseInt(b[6], 10) || 0, i = parseInt(b[7], 10) || 0, l = parseInt(b[10], 10) || 0, m = parseInt(b[11], 10) || 0, "Z" !== b[8] && (k = 60 * l + m, "+" === b[9] && (o = 0 - o)), n = Date.UTC(c, d, e, f, g + k, h, i)), n
                }

                function c(a) {
                    var b, c, d, e, f, g;
                    return a instanceof Date ? (b = a.getUTCMonth() + 1, 1 === b.toString().length && (b = Ericsson.String.padLeft(b, "0", 1)), c = a.getUTCDate(), 1 === c.toString().length && (c = Ericsson.String.padLeft(c, "0", 1)), d = a.getUTCHours(), 1 === d.toString().length && (d = Ericsson.String.padLeft(d, "0", 1)), e = a.getUTCMinutes(), 1 === e.toString().length && (e = Ericsson.String.padLeft(e, "0", 1)), f = a.getUTCSeconds(), 1 === f.toString().length && (f = Ericsson.String.padLeft(f, "0", 1)), g = a.getUTCMilliseconds(), 1 === g.toString().length ? g = Ericsson.String.padLeft(g, "0", 2) : 2 === g.toString().length && (g = Ericsson.String.padLeft(g, "0", 1)), a.getUTCFullYear() + "-" + b + "-" + c + "T" + d + ":" + e + ":" + f + "." + g + "Z") : void Ericsson.Log.error("Error in Ericsson.Date.toISOString: Object of type Date was expected.")
                }

                function d(a) {
                    switch (Ericsson.type(a)) {
                        case "date":
                            return a;
                        case "array":
                            return new Date(a[0], a[1], a[2]);
                        case "number":
                            return new Date(a);
                        case "string":
                            return new Date(b(a));
                        case "object":
                            if (void 0 !== a.year && void 0 !== a.month && void 0 !== a.date) return new Date(a.year, a.month, a.date)
                    }
                    return NaN
                }

                function e(a, b, c) {
                    return isFinite(a = d(a).valueOf()) && isFinite(b = d(b).valueOf()) && isFinite(c = d(c).valueOf()) ? a >= b && c >= a : NaN
                }

                function f(a) {
                    var b = d(a);
                    return b.setHours(0), b.setMinutes(0), b.setSeconds(0), b.setMilliseconds(0), b
                }

                function g(b) {
                    var c = d(b);
                    return a(c, i.ShortDatePattern)
                }

                function h(b) {
                    var c = d(b);
                    return a(c, i.ShortTimePattern)
                }
                var i = {
                        ShortDatePattern: "M/d/yyyy",
                        ShortTimePattern: "h:mm tt",
                        AMDesignator: "AM",
                        PMDesignator: "PM"
                    },
                    j = /(\d{4})-?(\d{2})-?(\d{2})(?:[T ](\d{2}):?(\d{2}):?(\d{2})?(?:\.(\d{1,3})[\d]*)?(?:(Z)|([+\-])(\d{2})(?::?(\d{2}))?))/;
                try {
                    i = Sys.CultureInfo.CurrentCulture.dateTimeFormat
                } catch (k) {}
                return {
                    parse: b,
                    toISOString: c,
                    convert: d,
                    inRange: e,
                    zeroTime: f,
                    getShortDateFormat: g,
                    getShortDateTimeFormat: h
                }
            }()), Ericsson.namespace("Guid").extend(function() {
                function a(a) {
                    return a.replace(i, "")
                }

                function b(b) {
                    return "{" + a(b) + "}"
                }

                function c(a) {
                    return "string" !== Ericsson.type(a) ? !1 : (a = e(a), j.test(a))
                }

                function d(a) {
                    if (!c(a)) return null;
                    a = e(a);
                    var b = k.exec(a);
                    return a = Ericsson.String.format("{{0}-{1}-{2}-{3}-{4}}", b[1], b[2], b[3], b[4], b[5])
                }

                function e(a) {
                    return "string" !== Ericsson.type(a) ? null : a.replace(l, "").toUpperCase()
                }

                function f() {
                    var a = [],
                        b = Array.prototype.slice.call(arguments, 0);
                    return Ericsson.each(b, function() {
                        a.push(e(this))
                    }), Ericsson.areEqual.apply(null, a)
                }

                function g(a) {
                    switch (a = a || "db", a.toLowerCase()) {
                        case "n":
                            return m;
                        case "b":
                            return o;
                        case "db":
                        case "bd":
                            return p;
                        case "d":
                            return n;
                        default:
                            return p
                    }
                }

                function h(a) {
                    return f(a, g())
                }
                var i = /[{}]/g,
                    j = /^([0-9A-F]{32})$/,
                    k = /^([0-9A-F]{8})([0-9A-F]{4})([0-9A-F]{4})([0-9A-F]{4})([0-9A-F]{12})$/,
                    l = /[\s{}\-]/g,
                    m = "00000000000000000000000000000000",
                    n = "00000000-0000-0000-0000-000000000000",
                    o = "{00000000000000000000000000000000}",
                    p = "{00000000-0000-0000-0000-000000000000}";
                return {
                    decapsulate: a,
                    encapsulate: b,
                    isValid: c,
                    isEmpty: h,
                    format: d,
                    areEqual: f,
                    empty: g
                }
            }()), Ericsson.namespace("Cache").extend(function() {
                function a(a) {
                    var b, c, e = 0;
                    for (b = d.length; b > e; e++)
                        if (d[e].name === a) return d[e];
                    return c = {
                        name: a,
                        data: []
                    }, d.push(c), c
                }

                function b(b, c) {
                    var d, e = a(b),
                        f = 0;
                    for (d = e.data.length; d > f; f++)
                        if (e.data[f].key === c) return e.data[f].value;
                    return null
                }

                function c(b, c, d) {
                    var e, f = a(b),
                        g = 0;
                    for (e = f.data.length; e > g; g++)
                        if (f.data[g].key === c) return void(f.data[g].value = d);
                    f.data.push({
                        key: c,
                        value: d
                    })
                }
                var d = [];
                return {
                    get: b,
                    set: c
                }
            }()), Ericsson.namespace("LocalStorage").extend(function() {
                function a(a) {
                    var b, c = null,
                        d = window.localStorage.getItem(a);
                    return d && (d = JSON.parse(d), b = d.expiration || 0, b && b <= (new Date).valueOf() ? window.localStorage.removeItem(a) : c = d.value), c
                }

                function b(a, b, c) {
                    var e;
                    null === b ? window.localStorage.removeItem(a) : (b = {
                        value: b,
                        expiration: null
                    }, c && (e = new Date((new Date).valueOf() + d * c), b.expiration = e.valueOf()), window.localStorage.setItem(a, JSON.stringify(b)))
                }

                function c(a) {
                    window.localStorage.removeItem(a)
                }
                var d = 36e5;
                return window.localStorage || (window.localStorage = {
                    getItem: function() {
                        return null
                    },
                    setItem: function() {},
                    removeItem: function() {}
                }), {
                    set: b,
                    get: a,
                    remove: c
                }
            }()), Ericsson.namespace("Log").extend(function() {
                function a() {
                    window.console && console.log && Function.prototype.apply.call(console.log, console, arguments), o.push.apply(o, arguments)
                }

                function b() {
                    window.console && console.info ? Function.prototype.apply.call(console.info, console, arguments) : window.console && console.log && Function.prototype.apply.call(console.log, console, arguments), o.push.apply(o, arguments)
                }

                function c() {
                    window.console && console.warn ? Function.prototype.apply.call(console.warn, console, arguments) : window.console && console.log && Function.prototype.apply.call(console.log, console, arguments), o.push.apply(o, arguments)
                }

                function d() {
                    window.console && console.error ? Function.prototype.apply.call(console.error, console, arguments) : window.console && console.log && Function.prototype.apply.call(console.log, console, arguments), o.push.apply(o, arguments)
                }

                function e() {
                    return o
                }

                function f() {
                    o = []
                }

                function g() {
                    window.console && console.group ? console.group() : window.console && console.log && console.log("+++")
                }

                function h() {
                    window.console && console.groupEnd ? console.groupEnd() : window.console && console.log && console.log("---")
                }

                function i() {
                    window.console && console.groupCollapsed ? console.groupCollapsed() : g()
                }

                function j(a) {
                    a || (a = "default"), window.console && console.time ? console.time(a) : p[a] = l()
                }

                function k(b) {
                    b || (b = "default"), window.console && console.timeEnd ? console.timeEnd(b) : p[b] && (a(b + ": " + (l() - p[b]) + "ms"), delete p[b])
                }

                function l() {
                    return Date.now ? Date.now() : (new Date).getTime()
                }

                function m(a) {
                    window.console && console.dir ? console.dir(a) : window.console && console.log && JSON && JSON.stringify && console.log(JSON.stringify(a))
                }

                function n() {
                    window.console && console.trace ? console.trace() : window.console && console.error ? console.error("Stracktrace") : window.console && console.log && console.log("console.trace not available on this browser.");
                }
                var o = [],
                    p = {};
                return {
                    log: a,
                    debug: a,
                    info: b,
                    warn: c,
                    error: d,
                    getLogs: e,
                    clearLogs: f,
                    group: g,
                    groupEnd: h,
                    groupCollapsed: i,
                    time: j,
                    timeEnd: k,
                    dir: m,
                    trace: n
                }
            }()), Ericsson.namespace("Xml").extend(function(a) {
                "use strict";

                function b(a) {
                    return "array" === Ericsson.type(a) && (a = a.join("")), "string" !== Ericsson.type(a) && (a = a.toString()), a.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;").replace(/"/g, "&quot;").replace(/'/g, "&#39;")
                }

                function c(a) {
                    return a.replace(k, "*[local-name()='$1']")
                }

                function d(a, b) {
                    var d = a.ownerDocument || a;
                    return d.evaluate(c(b), a, null, XPathResult.ANY_TYPE, null)
                }

                function e(a, b) {
                    var c = d(a, b).iterateNext();
                    return c && (c.text = c.textContent), c
                }

                function f(a, b) {
                    for (var c = [], e = d(a, b), f = e.iterateNext(); f;) c.push(f), f = e.iterateNext();
                    return c
                }

                function g(b) {
                    if (!i)
                        if (window.ActiveXObject !== a && new window.ActiveXObject("Microsoft.XMLDOM")) i = function(a) {
                            var b = new window.ActiveXObject("Microsoft.XMLDOM");
                            return b.async = "false", b.loadXML(a), b
                        };
                        else {
                            if (!window.DOMParser || "undefined" == typeof XMLDocument || "undefined" == typeof XPathResult) throw new Error("No XML parser found.");
                            i = function(a) {
                                return (new window.DOMParser).parseFromString(a, "text/xml")
                            }
                        }
                    return i(b)
                }

                function h(a) {
                    if (!(this instanceof h)) return new h(a);
                    if ("undefined" == typeof a) throw new Error("tagName is required.");
                    this.tagName = a, this.attributes = {}, this.elements = []
                }
                var i, j, k = /(?:\w+:)?(\w+)/g;
                return j = function() {
                    var b, c;
                    return window.ActiveXObject !== a && new window.ActiveXObject("Microsoft.XMLDOM") ? (b = function(a, b) {
                        return a.selectSingleNode(b)
                    }, c = function(a, b) {
                        return a.selectNodes(b)
                    }) : (b = e, c = f, XMLDocument.prototype.selectSingleNode = Element.prototype.selectSingleNode = function(a) {
                        return b(this, a)
                    }, XMLDocument.prototype.selectNodes = Element.prototype.selectNodes = function(a) {
                        return c(this, a)
                    }), {
                        selectSingleNode: b,
                        selectNodes: c
                    }
                }(), h.prototype = function() {
                    function a(a, c) {
                        if ("undefined" == typeof a) throw new Error("key is required.");
                        this.attributes[a] = b(c.toString())
                    }

                    function c(a) {
                        if ("undefined" == typeof a) throw new Error("element is required.");
                        if (a instanceof Array)
                            for (var b = 0; b < a.length; ++b) this.elements.push(a[b]);
                        else this.elements.push(a)
                    }

                    function d(a) {
                        for (var b = []; a--;) b.push("	");
                        return b.join("")
                    }

                    function e(a, c) {
                        var e, f, g, i, j, k = "undefined" != typeof a ? a : !1,
                            l = [];
                        c = c || 0, e = d(c++), k && l.push(e), l.push("<" + this.tagName);
                        for (f in this.attributes) this.attributes.hasOwnProperty(f) && l.push(" " + f + "='" + this.attributes[f] + "'");
                        if (0 === this.elements.length) l.push(" />");
                        else {
                            for (l.push(">"), g = 0, i = this.elements.length; i > g; ++g) j = this.elements[g], j instanceof h ? (k && l.push("\n"), l.push(j.toString(k, c))) : (k && l.push("\n" + d(c)), l.push(b(j.toString())));
                            k && l.push("\n" + e), l.push("</" + this.tagName + ">")
                        }
                        return l.join("")
                    }
                    return {
                        addAttribute: a,
                        addElement: c,
                        toString: e
                    }
                }(), {
                    XmlObject: h,
                    xmlEncode: b,
                    loadXml: g,
                    selectSingleNode: j.selectSingleNode,
                    selectNodes: j.selectNodes
                }
            }()),
            function(a, b) {
                b.Promise.prototype.done = function() {
                    return a.Log.warn(["Deprecation warning: 'done' will be removed in the next major release. ", "Please switch to using 'then' as outlined in the Promises/A+ specification."].join("")), b.Promise.prototype.then.apply(this, arguments)
                }, b.Promise.prototype.fail = function() {
                    return a.Log.warn(["Deprecation warning: 'fail' will be removed in the next major release. ", "Please switch to using 'catch' (or 'caught') as outlined in the Promises/A+ specification."].join("")), b.Promise.prototype["catch"].apply(this, arguments)
                }, a.Promise = b, a.Promise.resolve = function() {
                    var b = arguments;
                    return new a.Promise.Promise(function(a, c) {
                        a.apply(this, b)
                    })
                }, a.Promise.reject = function() {
                    var b = arguments;
                    return new a.Promise.Promise(function(a, c) {
                        c.apply(this, b)
                    })
                }
            }(Ericsson, RSVP), Ericsson.namespace("Fetch").extend(function() {
                "use strict";

                function a(a, b, c, d) {
                    if ("undefined" == typeof a) throw new Error("name is required.");
                    var e = new Ericsson.Xml.XmlObject("attribute");
                    return e.addAttribute("name", a), b && e.addAttribute("aggregate", "countcolumn"), c && e.addAttribute("alias", c), d && e.addAttribute("distinct", d), e
                }

                function b(a, b) {
                    if ("undefined" == typeof a) throw new Error("attribute is required.");
                    var c = new Ericsson.Xml.XmlObject("order");
                    return c.addAttribute("attribute", a), c.addAttribute("descending", b || !1), c
                }

                function c(a, b, d, e) {
                    var f, g;
                    if (!(this instanceof c)) return new c(a, b, d, e);
                    if ("undefined" == typeof a) throw new Error("entityName is required.");
                    f = new Ericsson.Xml.XmlObject("fetch"), f.addAttribute("mapping", "logical"), b && f.addAttribute("count", b), this.isAggregate = "undefined" != typeof d ? d : !1, this.isAggregate && f.addAttribute("aggregate", this.isAggregate), this.isDistinct = "undefined" != typeof e ? e : !1, this.isDistinct && f.addAttribute("distinct", this.isDistinct), f.addAttribute("version", "1.0"), g = new Ericsson.Xml.XmlObject("entity"), g.addAttribute("name", a), f.addElement(g), this.rootXml = f, this.entityXml = g, this.filterAdded = !1
                }

                function d(a) {
                    if (!(this instanceof d)) return new d(a);
                    var b = new Ericsson.Xml.XmlObject("filter");
                    a && b.addAttribute("type", "or"), this.rootXml = b
                }

                function e(a, b, c, d, f) {
                    if (!(this instanceof e)) return new e(a, b, c, f, d);
                    if ("undefined" == typeof a) throw new Error("toEntity is required.");
                    if ("undefined" == typeof b) throw new Error("fromAttribute is required.");
                    if ("undefined" == typeof c) throw new Error("toAttribute is required.");
                    var g = new Ericsson.Xml.XmlObject("link-entity");
                    g.addAttribute("name", a), g.addAttribute("from", b), g.addAttribute("to", c), f && g.addAttribute("alias", f), d && g.addAttribute("link-type", d), this.rootXml = g, this.filterAdded = !1
                }
                var f = {
                        isBetween: "between",
                        isEqualTo: "eq",
                        isEqualToBusinessUnitId: "eq-businessid",
                        isEqualToUserId: "eq-userid",
                        isGreaterThan: "gt",
                        isGreaterThanOrEqualTo: "ge",
                        isIn: "in",
                        isLessThan: "lt",
                        isLessThanOrEqualTo: "le",
                        isLike: "like",
                        isNotBetween: "not-between",
                        isNotEqualTo: "ne",
                        isNotEqualToBusinessUnitId: "ne-businessid",
                        isNotEqualToUserId: "ne-userid",
                        isNotIn: "not-in",
                        isNotLike: "not-like",
                        isNotNull: "not-null",
                        isNull: "null",
                        isOn: "on",
                        isOnOrAfter: "on-or-after",
                        isOnOrBefore: "on-or-before",
                        isWithinLast7Days: "last-seven-days",
                        isWithinLastMonth: "last-month",
                        isWithinLastXDays: "last-x-days",
                        isWithinLastXHours: "last-x-hours",
                        isWithinLastXMonths: "last-x-months",
                        isWithinLastXWeeks: "last-x-weeks",
                        isWithinLastXYears: "last-x-years",
                        isWithinLastYear: "last-year",
                        isWithinNext7Days: "next-seven-days",
                        isWithinNextMonth: "next-month",
                        isWithinNextWeek: "next-week",
                        isWithinNextXDays: "next-x-days",
                        isWithinNextXHours: "next-x-hours",
                        isWithinNextXMonths: "next-x-months",
                        isWithinNextXWeeks: "next-x-weeks",
                        isWithinNextXYears: "next-x-years",
                        isWithinNextYear: "next-year",
                        isWithinThisMonth: "this-month",
                        isWithinThisWeek: "this-week",
                        isWithinThisYear: "this-year",
                        isWithinToday: "today",
                        isWithinTomorrow: "tomorrow",
                        isWithinYesterday: "yesterday"
                    },
                    g = {
                        inner: "inner",
                        natural: "natural",
                        outer: "outer"
                    };
                return c.prototype = function() {
                    function c(b, c, d) {
                        var e = a(b, this.isAggregate, c, d);
                        return this.entityXml.addElement(e), this
                    }

                    function f(a, c) {
                        var d = b(a, c);
                        return this.entityXml.addElement(d), this
                    }

                    function g(a) {
                        if (!(a instanceof d)) throw new Error("filter must be a Filter type.");
                        if (this.filterAdded) throw new Error("Only one filter may be added per fetch. Filters can be nested inside each other.");
                        return this.entityXml.addElement(a.rootXml), this.filterAdded = !0, this
                    }

                    function h(a) {
                        if (!(a instanceof e)) throw new Error("linkEntity must be a LinkEntity type.");
                        return this.entityXml.addElement(a.rootXml), this
                    }

                    function i(a) {
                        return this.rootXml.toString(a)
                    }
                    return {
                        addAttribute: c,
                        addOrder: f,
                        addFilter: g,
                        addLinkEntity: h,
                        toString: i
                    }
                }(), d.prototype = function() {
                    function a(a, b, c) {
                        var d, e, f = 0;
                        if ("undefined" == typeof a) throw new Error("attribute is required.");
                        if ("undefined" == typeof b) throw new Error("operator is required.");
                        if (d = new Ericsson.Xml.XmlObject("condition"), d.addAttribute("attribute", a), d.addAttribute("operator", b), c instanceof Array)
                            for (f; f < c.length; ++f) e = new Ericsson.Xml.XmlObject("value"), e.addElement(c[f]), d.addElement(e);
                        else c && d.addAttribute("value", c);
                        return this.rootXml.addElement(d), this
                    }

                    function b(a) {
                        if (!(a instanceof d)) throw new Error("filter must be a Filter type.");
                        return this.rootXml.addElement(a.rootXml), this
                    }
                    return {
                        addCondition: a,
                        addFilter: b
                    }
                }(), e.prototype = function() {
                    function c(b) {
                        var c = a(b);
                        return this.rootXml.addElement(c), this
                    }

                    function f(a, c) {
                        var d = b(a, c);
                        return this.rootXml.addElement(d), this
                    }

                    function g(a) {
                        if (!(a instanceof d)) throw new Error("filter must be a Filter type.");
                        if (this.filterAdded) throw new Error("Only one filter may be added per fetch. Filters can be nested inside each other.");
                        return this.rootXml.addElement(a.rootXml), this.filterAdded = !0, this
                    }

                    function h(a) {
                        if (!(a instanceof e)) throw new Error("linkEntity must be a LinkEntity type.");
                        return this.rootXml.addElement(a.rootXml), this
                    }
                    return {
                        addAttribute: c,
                        addOrder: f,
                        addFilter: g,
                        addLinkEntity: h
                    }
                }(), {
                    FetchXml: c,
                    Filter: d,
                    LinkEntity: e,
                    Operators: f,
                    JoinTypes: g
                }
            }()), Ericsson.namespace("QueryBuilder").extend(function() {
                "use strict";

                function a() {
                    this.entityName = null, this.attributes = [], this.orders = [], this.filters = [], this.joins = []
                }

                function b(a, b, c) {
                    this.attribute = a, this.operator = b, this.values = c
                }
                return a.prototype = function() {
                    function a(a) {
                        if ("string" != typeof a) throw new Error("entityName must be a string.");
                        return this.entityName = a, this
                    }

                    function c(a) {
                        if (a instanceof Array)
                            for (var b = 0; b < a.length; ++b) this.attributes.push(a[b]);
                        else "string" == typeof a && this.attributes.push(a);
                        return this
                    }

                    function d() {
                        return this.attributes = [], this
                    }

                    function e(a, b, c, d, e, f) {
                        for (var g = {
                                toEntity: a,
                                fromAttribute: b,
                                toAttribute: c,
                                joinType: d,
                                alias: f
                            }, h = [], i = 0; i < e.length; ++i) h.push(e[i]);
                        return g.filters = {
                            conditions: h
                        }, this.joins.push(g), this
                    }

                    function f(a, c, d) {
                        return this.filters.push({
                            conditions: [new b(a, c, d)]
                        }), this
                    }

                    function g(a, b) {
                        var c = {};
                        return c.attribute = a, c.isDescending = b, this.orders.push(c), this
                    }

                    function h(a, b) {
                        var c = new Ericsson.Fetch.LinkEntity(b.toEntity, b.fromAttribute, b.toAttribute, b.joinType, b.alias),
                            d = i(b.filters);
                        c.addFilter(d), a.addLinkEntity(c)
                    }

                    function i(a) {
                        for (var b, c = new Ericsson.Fetch.Filter(a.isOr), d = 0; d < a.conditions.length; ++d) b = a.conditions[d], c.addCondition(b.attribute, b.operator, b.values);
                        return c
                    }

                    function j() {
                        var a, b = new Ericsson.Fetch.FetchXml(this.entityName),
                            c = 0;
                        for (c = 0; c < this.attributes.length; ++c) b.addAttribute(this.attributes[c]);
                        for (c = 0; c < this.orders.length; ++c) b.addOrder(this.orders[c].attribute, this.orders[c].isDescending);
                        for (c = 0; c < this.filters.length; ++c) a = i(this.filters[c]), b.addFilter(a);
                        for (c = 0; c < this.joins.length; ++c) h(b, this.joins[c]);
                        return b.toString()
                    }
                    return {
                        From: a,
                        Select: c,
                        SelectAll: d,
                        Join: e,
                        Order: g,
                        toString: j,
                        Where: f
                    }
                }(), Ericsson.QB = Ericsson.QueryBuilder, {
                    Query: a,
                    Condition: b
                }
            }()), Ericsson.namespace("OrgService").extend(function() {
                "use strict";

                function a(a) {
                    var b, c, d;
                    if (b = "array" !== Ericsson.type(a), c = ["<columnSet ", wa.xrm, ">", "<a:AllColumns>", b.toString(), "</a:AllColumns>", "<a:Columns ", wa.arrays, ">"], !b)
                        for (d = 0; d < a.length; d++) "string" === Ericsson.type(a[d]) && c.push(Ericsson.String.format("<b:string>{0}</b:string>", a[d]));
                    return c.push("</a:Columns>"), c.push("</columnSet>"), c.join("")
                }

                function b(a, b) {
                    var c, d = {};
                    for (c in a) a.hasOwnProperty(c) && (d[c] = a[c]);
                    for (c in b) b.hasOwnProperty(c) && (d[c] = b[c]);
                    return d
                }

                function c(a) {
                    return "undefined" == typeof a
                }

                function d(a) {
                    return null === a
                }

                function e(a) {
                    var b, c, d;
                    b = [];
                    for (c in a)
                        if ("Metadata" !== c && a.hasOwnProperty(c)) {
                            if (b.push("<a:KeyValuePairOfstringanyType>"), b.push(Ericsson.String.format("<b:key>{0}</b:key>", c)), d = a[c], "undefined" === Ericsson.type(d) || null === d) return void alert("To set an attribute to null, set its value to a new instance of the OrgService.NullValue class.");
                            switch (Ericsson.type(d)) {
                                case "string":
                                    b.push('<b:value i:type="c:string" ' + wa.xml + ">" + Ericsson.Xml.xmlEncode(a[c]) + "</b:value>");
                                    break;
                                case "number":
                                    b.push('<b:value i:type="c:int" ' + wa.xml + ">" + a[c] + "</b:value>");
                                    break;
                                default:
                                    d instanceof ma == !1 && alert("The attribute " + c + " is a complex type, but can not be serialized.  Make sure you define the attribute using the appropriate class (new Ericsson.OrgService.[Boolean|DateTime|Decimal|EntityReference|Guid|OptionSetValue])."), b.push(d.toXml())
                            }
                            b.push("</a:KeyValuePairOfstringanyType>")
                        }
                    return b.join("")
                }

                function f(a, b, c) {
                    if ("object" !== Ericsson.type(c)) return void alert("Entity is not an object, cannot continue operation.");
                    d(b) && (b = "00000000-0000-0000-0000-000000000000"), d(a) && alert("LogicalName was not specified, cannot continue operation.");
                    var f = ["<entity ", wa.xrm, ">", "<a:Attributes ", wa.collection, ">", e(c), "</a:Attributes>", '<a:EntityState i:nil="true" />', "<a:FormattedValues ", wa.collection, " />", "<a:Id>" + b + "</a:Id>", "<a:LogicalName>" + a + "</a:LogicalName>", "<a:RelatedEntities ", wa.collection, " />", "</entity>"];
                    return f.join("")
                }

                function g(a, b, c, d) {
                    var e;
                    return e = new Ericsson.OrgService.OptionSetValue, d ? e.Value = parseInt(b.selectSingleNode("b:value/a:Value/a:Value").text, 10) : e.Value = parseInt(b.selectSingleNode("b:value/a:Value").text, 10), a && a.hasOwnProperty(c) && (e.Label = a[c]), e
                }

                function h(a, b) {
                    var c, e;
                    return c = new Ericsson.OrgService.EntityReference, e = "b:value/", b && (e = "b:value/a:Value/"), d(a.selectSingleNode(e + "a:Id")) || (c.Id = a.selectSingleNode(e + "a:Id").text), d(a.selectSingleNode(e + "a:Name")) || (c.Name = a.selectSingleNode(e + "a:Name").text), d(a.selectSingleNode(e + "a:LogicalName")) || (c.LogicalName = a.selectSingleNode(e + "a:LogicalName").text), c
                }

                function i(a, b, c, d) {
                    var e, f;
                    return e = new Ericsson.OrgService.Money, f = "b:value/", d && (f = "b:value/a:Value/"), e.Value = parseFloat(b.selectSingleNode(f + "a:Value").text), a && a.hasOwnProperty(c) && (e.DisplayValue = a[c]), e
                }

                function j(a, b) {
                    var c, d;
                    return c = new Ericsson.OrgService.Guid, d = "b:value", b && (d = "b:value/a:Value"), c.Value = a.selectSingleNode(d).text, c
                }

                function k(a, b) {
                    var c;
                    return c = b ? parseInt(a.selectSingleNode("b:value/a:Value").text, 10) : parseInt(a.selectSingleNode("b:value").text, 10)
                }

                function l(a, b, c, d) {
                    var e, f;
                    return e = new Ericsson.OrgService.Decimal, f = "b:value", d && (f = "b:value/a:Value"), e.Value = parseFloat(b.selectSingleNode(f).text, 10), a && a.hasOwnProperty(c) && (e.DisplayValue = a[c]), e
                }

                function m(a, b, c, d) {
                    var e, f;
                    return e = new Ericsson.OrgService.Boolean, f = "b:value", d && (f = "b:value/a:Value"), e.Value = "true" === b.selectSingleNode(f).text, a && a.hasOwnProperty(c) && (e.DisplayValue = a[c]), e
                }

                function n(a, b, c, d) {
                    var e, f, g;
                    return e = new Ericsson.OrgService.DateTime, f = "b:value", d && (f = "b:value/a:Value"), e.UTC = b.selectSingleNode(f).text, a && a.hasOwnProperty(c) && (e.DisplayValue = a[c], g = Ericsson.Date.parse(e.UTC), e.Value = new Date(g)), e
                }

                function o(a) {
                    var b, c;
                    return b = a.selectSingleNode("b:key").text, c = b.split("."), 2 !== c.length ? null : c[0]
                }

                function p(a, b, c) {
                    var d, e, f, o;
                    switch (d = {
                        _type: "Entity",
                        EntityLogicalName: b.selectSingleNode("b:value/a:EntityLogicalName").text
                    }, e = b.selectSingleNode("b:value/a:AttributeLogicalName").text, f = b.selectSingleNode("b:value/a:Value").getAttribute("i:type"), o = b.selectSingleNode("b:value/a:Value").text, f) {
                        case "c:guid":
                            o = j(b, !0);
                            break;
                        case "a:OptionSetValue":
                            o = g(a, b, c, !0);
                            break;
                        case "a:EntityReference":
                            o = h(b, !0);
                            break;
                        case "a:Money":
                            o = i(a, b, c, !0);
                            break;
                        case "c:dateTime":
                            o = n(a, b, c, !0);
                            break;
                        case "c:decimal":
                            o = l(a, b, c, !0);
                            break;
                        case "c:int":
                            o = k(b, !0);
                            break;
                        case "c:boolean":
                            o = m(a, b, c, !0);
                            break;
                        case "a:AliasedValue":
                            alert("Unsupported parsing of multi-tiered aliased/linked entities");
                            break;
                        case "c:string":
                    }
                    return e && (d[e] = o), d
                }

                function q(a) {
                    var b, c;
                    return b = {
                        MoreRecords: !1,
                        TotalRecordCount: -1,
                        TotalRecordCountLimitExceeded: !1,
                        PagingCookie: null
                    }, c = a.selectSingleNode("s:Envelope/s:Body/RetrieveMultipleResponse/RetrieveMultipleResult"), c.selectSingleNode("a:TotalRecordCount") && !isNaN(parseInt(c.selectSingleNode("a:TotalRecordCount").text, 10)) && (b.TotalRecordCount = parseInt(c.selectSingleNode("a:TotalRecordCount").text, 10)), c.selectSingleNode("a:TotalRecordCountLimitExceeded") && (b.TotalRecordCountLimitExceeded = "true" === c.selectSingleNode("a:TotalRecordCountLimitExceeded").text), c.selectSingleNode("a:PagingCookie") && (b.PagingCookie = c.selectSingleNode("a:PagingCookie").text.replace(/</g, "&lt;").replace(/>/g, "&gt;").replace(/"/g, "&quot;")), c.selectSingleNode("a:MoreRecords") && (b.MoreRecords = "true" === c.selectSingleNode("a:MoreRecords").text), b
                }

                function r(a, c) {
                    var d, e, f, q, r, s, t, u, v;
                    if (d = {
                            Metadata: {
                                RelatedEntityCount: 0,
                                AttributeCount: 0
                            }
                        }, "array" === Ericsson.type(c))
                        for (v = 0; v < c.length; v++) d[c[v]] = null;
                    if (e = {}, f = a.selectSingleNode("a:FormattedValues"), f.childNodes.length > 0)
                        for (v = 0; v < f.childNodes.length; v++) u = f.childNodes[v].selectSingleNode("b:key").text, t = f.childNodes[v].selectSingleNode("b:value").text, u && (e[u] = t);
                    if (q = a.selectSingleNode("a:Attributes"), q.childNodes.length > 0)
                        for (d.Metadata.AttributeCount = q.childNodes.length, d.Metadata.RelatedEntityCount = 0, v = 0; v < q.childNodes.length; v++) {
                            switch (r = q.childNodes[v], s = r.selectSingleNode("b:value").getAttribute("i:type"), t = r.selectSingleNode("b:value").text, u = r.selectSingleNode("b:key").text, s) {
                                case "c:guid":
                                    t = j(r);
                                    break;
                                case "a:OptionSetValue":
                                    t = g(e, r, u);
                                    break;
                                case "a:EntityReference":
                                    t = h(r);
                                    break;
                                case "a:Money":
                                    t = i(e, r, u);
                                    break;
                                case "c:dateTime":
                                    t = n(e, r, u);
                                    break;
                                case "c:decimal":
                                    t = l(e, r, u);
                                    break;
                                case "c:int":
                                    t = k(r);
                                    break;
                                case "c:boolean":
                                    t = m(e, r, u);
                                    break;
                                case "a:AliasedValue":
                                    d.Metadata.RelatedEntityCount++, t = p(e, r, u), u = o(r), u || (d[r.selectSingleNode("b:key").text] = t[r.selectSingleNode("b:value/a:AttributeLogicalName").text]), d.hasOwnProperty(u) ? d[u] = b(d[u], t) : u && (d[u] = t), u = null;
                                    break;
                                case "c:string":
                            }
                            u && (d[u] = t)
                        }
                    return d.Metadata.Id = a.selectSingleNode("a:Id").text, d.Metadata.LogicalName = a.selectSingleNode("a:LogicalName").text, d
                }

                function s(a) {
                    var b = a.selectSingleNode("s:Envelope/s:Body/CreateResponse/CreateResult").text;
                    return b
                }

                function t(a, b) {
                    var c;
                    return c = r(a.selectSingleNode("s:Envelope/s:Body/RetrieveResponse/RetrieveResult"), b)
                }

                function u(a) {
                    var b, c, d, e;
                    if (b = q(a), c = a.selectSingleNode("s:Envelope/s:Body/RetrieveMultipleResponse/RetrieveMultipleResult/a:Entities"), d = [], c.childNodes.length > 0) {
                        for (e = 0; e < c.childNodes.length; e++) d.push(r(c.childNodes[e]));
                        return {
                            Entities: d,
                            Paging: b
                        }
                    }
                    return {
                        Entities: [],
                        Paging: null
                    }
                }

                function v(a) {
                    var b = a.selectSingleNode("s:Envelope/s:Body/ExecuteResponse/ExecuteResult/a:Results/a:KeyValuePairOfstringanyType/c:value"),
                        c = b ? b.text : null;
                    return c
                }

                function w(a) {
                    var b = r(a.selectSingleNode("s:Envelope/s:Body/ExecuteResponse/ExecuteResult/a:Results/a:KeyValuePairOfstringanyType/c:value"));
                    return b
                }

                function x(a, b) {
                    return {
                        Success: a,
                        Value: b
                    }
                }

                function y(a, b, c) {
                    var d = ['<request i:type="c:' + a + '" ', wa.xrm, " ", wa.crm, ">", "<a:Parameters ", wa.collection, ">", c, "</a:Parameters>", '<a:RequestId i:nil="true" />', "<a:RequestName>", b, "</a:RequestName>", "</request>"];
                    return d.join("")
                }

                function z(a, b) {
                    var c = ["<a:KeyValuePairOfstringanyType>", "<b:key>", a, "</b:key>", b, "</a:KeyValuePairOfstringanyType>"];
                    return c.join("")
                }

                function A(a, b, c) {
                    var d = ['<request i:type="c:AssignRequest" xmlns:a="http://schemas.microsoft.com/xrm/2011/Contracts" xmlns:c="http://schemas.microsoft.com/crm/2011/Contracts">', '<a:Parameters xmlns:b="http://schemas.datacontract.org/2004/07/System.Collections.Generic">', "<a:KeyValuePairOfstringanyType>", "<b:key>Target</b:key>", b.toXml(), "</a:KeyValuePairOfstringanyType>", "<a:KeyValuePairOfstringanyType>", "<b:key>Assignee</b:key>", a.toXml(), "</a:KeyValuePairOfstringanyType>", "</a:Parameters>", '<a:RequestId i:nil="true" />', "<a:RequestName>Assign</a:RequestName>", "</request>"].join("");
                    return c ? ia(d, "Execute") : ja(d, "Execute")
                }

                function B(a, b) {
                    return A(a, b, !0)
                }

                function C(a, b) {
                    return A(a, b, !1)
                }

                function D(a, b, c, d) {
                    var e, f = "",
                        g = b.length,
                        h = 0;
                    if (b && g)
                        for (; g > h; h++) f += ["<a:EntityReference>", "<a:Id>", b[h].Id, "</a:Id>", "<a:LogicalName>", b[h].LogicalName, "</a:LogicalName>", '<a:Name i:nil="true" />', "</a:EntityReference>"].join("");
                    else f = ["<a:EntityReference>", "<a:Id>", b.Id, "</a:Id>", "<a:LogicalName>", b.LogicalName, "</a:LogicalName>", '<a:Name i:nil="true" />', "</a:EntityReference>"].join("");
                    return e = ['<request i:type="a:AssociateRequest" xmlns:a="http://schemas.microsoft.com/xrm/2011/Contracts">', '<a:Parameters xmlns:b="http://schemas.datacontract.org/2004/07/System.Collections.Generic">', "<a:KeyValuePairOfstringanyType>", "<b:key>Target</b:key>", '<b:value i:type="a:EntityReference">', "<a:Id>", a.Id, "</a:Id>", "<a:LogicalName>", a.LogicalName, "</a:LogicalName>", '<a:Name i:nil="true" />', "</b:value>", "</a:KeyValuePairOfstringanyType>", "<a:KeyValuePairOfstringanyType>", "<b:key>Relationship</b:key>", '<b:value i:type="a:Relationship">', '<a:PrimaryEntityRole i:nil="true" />', "<a:SchemaName>", c, "</a:SchemaName>", "</b:value>", "</a:KeyValuePairOfstringanyType>", "<a:KeyValuePairOfstringanyType>", "<b:key>RelatedEntities</b:key>", '<b:value i:type="a:EntityReferenceCollection">', f, "</b:value>", "</a:KeyValuePairOfstringanyType>", "</a:Parameters>", '<a:RequestId i:nil="true" />', "<a:RequestName>Associate</a:RequestName>", "</request>"].join(""), d ? ia(e, "Execute") : ja(e, "Execute")
                }

                function E(a, b, c) {
                    return D(a, b, c, !0)
                }

                function F(a, b, c) {
                    return D(a, b, c, !1)
                }

                function G(a, b, c, d) {
                    var e, f = "",
                        g = b.length,
                        h = 0;
                    if (b && g)
                        for (; g > h; h++) f += ["<a:EntityReference>", "<a:Id>", b[h].Id, "</a:Id>", "<a:LogicalName>", b[h].LogicalName, "</a:LogicalName>", '<a:Name i:nil="true" />', "</a:EntityReference>"].join("");
                    else f = ["<a:EntityReference>", "<a:Id>", b.Id, "</a:Id>", "<a:LogicalName>", b.LogicalName, "</a:LogicalName>", '<a:Name i:nil="true" />', "</a:EntityReference>"].join("");
                    return e = ['<request i:type="a:DisassociateRequest" xmlns:a="http://schemas.microsoft.com/xrm/2011/Contracts">', '<a:Parameters xmlns:b="http://schemas.datacontract.org/2004/07/System.Collections.Generic">', "<a:KeyValuePairOfstringanyType>", "<b:key>Target</b:key>", '<b:value i:type="a:EntityReference">', "<a:Id>", a.Id, "</a:Id>", "<a:LogicalName>", a.LogicalName, "</a:LogicalName>", '<a:Name i:nil="true" />', "</b:value>", "</a:KeyValuePairOfstringanyType>", "<a:KeyValuePairOfstringanyType>", "<b:key>Relationship</b:key>", '<b:value i:type="a:Relationship">', '<a:PrimaryEntityRole i:nil="true" />', "<a:SchemaName>", c, "</a:SchemaName>", "</b:value>", "</a:KeyValuePairOfstringanyType>", "<a:KeyValuePairOfstringanyType>", "<b:key>RelatedEntities</b:key>", '<b:value i:type="a:EntityReferenceCollection">', f, "</b:value>", "</a:KeyValuePairOfstringanyType>", "</a:Parameters>", '<a:RequestId i:nil="true" />', "<a:RequestName>Disassociate</a:RequestName>", "</request>"].join(""), d ? ia(e, "Execute") : ja(e, "Execute")
                }

                function H(a, b, c) {
                    return G(a, b, c, !0)
                }

                function I(a, b, c) {
                    return G(a, b, c, !1)
                }

                function J(a, b, c) {
                    var d = ['<request i:type="b:ExecuteWorkflowRequest" xmlns:a="http://schemas.microsoft.com/xrm/2011/Contracts" xmlns:b="http://schemas.microsoft.com/crm/2011/Contracts">', '<a:Parameters xmlns:c="http://schemas.datacontract.org/2004/07/System.Collections.Generic">', "<a:KeyValuePairOfstringanyType>", "<c:key>EntityId</c:key>", '<c:value i:type="d:guid" xmlns:d="http://schemas.microsoft.com/2003/10/Serialization/">', a, "</c:value>", "</a:KeyValuePairOfstringanyType>", "<a:KeyValuePairOfstringanyType>", "<c:key>WorkflowId</c:key>", '<c:value i:type="d:guid" xmlns:d="http://schemas.microsoft.com/2003/10/Serialization/">', b, "</c:value>", "</a:KeyValuePairOfstringanyType>", "</a:Parameters>", '<a:RequestId i:nil="true" />', "<a:RequestName>ExecuteWorkflow</a:RequestName>", "</request>"].join("");
                    return c ? ia(d, "Execute", v) : ja(d, "Execute", v)
                }

                function K(a, b) {
                    return J(a, b, !0)
                }

                function L(a, b) {
                    return J(a, b, !1)
                }

                function M(a, b, c, d) {
                    (!c || /\S/.test(c)) && (c = "All");
                    var e = ['<request i:type="b:InitializeFromRequest" xmlns:a="http://schemas.microsoft.com/xrm/2011/Contracts" xmlns:b="http://schemas.microsoft.com/crm/2011/Contracts">', '<a:Parameters xmlns:c="http://schemas.datacontract.org/2004/07/System.Collections.Generic">', "<a:KeyValuePairOfstringanyType>", "<c:key>EntityMoniker</c:key>", '<c:value i:type="a:EntityReference">', "<a:Id>", a.Id, "</a:Id>", "<a:LogicalName>", a.LogicalName, "</a:LogicalName>", '<a:Name i:nil="true" />', "</c:value>", "</a:KeyValuePairOfstringanyType>", "<a:KeyValuePairOfstringanyType>", "<c:key>TargetEntityName</c:key>", '<c:value i:type="d:string" xmlns:d="http://www.w3.org/2001/XMLSchema">', b, "</c:value>", "</a:KeyValuePairOfstringanyType>", "<a:KeyValuePairOfstringanyType>", "<c:key>TargetFieldType</c:key>", '<c:value i:type="b:TargetFieldType">', c, "</c:value>", "</a:KeyValuePairOfstringanyType>", "</a:Parameters>", '<a:RequestId i:nil="true" />', "<a:RequestName>InitializeFrom</a:RequestName>", "</request>"].join("");
                    return d ? ia(e, "Execute", w) : ja(e, "Execute", w)
                }

                function N(a, b, c) {
                    return M(a, b, c, !0)
                }

                function O(a, b, c) {
                    return M(a, b, c, !1)
                }

                function P(a, b, c, d) {
                    var e;
                    if (4 === a.readyState)
                        if (200 === a.status) e = Ericsson.Xml.loadXml(a.responseText), b && (e = b(e)), c(e);
                        else {
                            if (0 === a.status) return void(a = null);
                            d(Q(a))
                        }
                    a = null
                }

                function Q(a) {
                    var b, c, d, e, f, g, h, i, j, k, l = Ericsson.Xml.loadXml(a.responseText);
                    if (b = "Unknown Error (Unable to parse the fault)", c = 0, "object" === Ericsson.type(l)) try {
                        for (d = l.firstChild.firstChild, h = 0; h < d.childNodes.length; h++)
                            if (e = d.childNodes[h], "s:Fault" === e.nodeName) {
                                for (i = 0; i < e.childNodes.length; i++)
                                    for (f = e.childNodes[i], "faultstring" === f.nodeName && (b = f.text || f.textContent), j = 0; j < f.length; j++)
                                        if ("ErrorDetails" === f.nodeName) {
                                            if ("2" === c) return;
                                            g = this.childNodes[1].text, "OperationStatus" === this.childNodes[0].text && (!c || g > c) && (c = g)
                                        }
                                break
                            }
                    } catch (m) {}
                    return k = new Error(b), k.operationStatus = c, k
                }

                function R(a, b, c) {
                    var d;
                    return d = ["<entityName>", a, "</entityName>", "<id>", b, "</id>"].join(""), c ? ia(d, "Delete") : ja(d, "Delete")
                }

                function S(a, b) {
                    return R(a, b, !0)
                }

                function T(a, b) {
                    return R(a, b, !1)
                }

                function U(a, b, c) {
                    var d;
                    return d = f(a, null, b), c ? ia(d, "Create", s) : ja(d, "Create", s)
                }

                function V(a, b) {
                    return U(a, b, !0)
                }

                function W(a, b) {
                    return U(a, b, !1)
                }

                function X(a, b, c, d) {
                    var e;
                    return e = f(a, b, c), d ? ia(e, "Update") : ja(e, "Update")
                }

                function Y(a, b, c) {
                    return X(a, b, c, !0)
                }

                function Z(a, b, c) {
                    return X(a, b, c, !1)
                }

                function $(b, c, d, e) {
                    var f;
                    return f = ["<entityName>", b, "</entityName>", "<id>", c, "</id>"], f.push(a(d)), e ? ia(f.join(""), "Retrieve", function(a) {
                        return t(a, d)
                    }) : ja(f.join(""), "Retrieve", t)
                }

                function _(a, b, c) {
                    return $(a, b, c, !0)
                }

                function aa(a, b, c) {
                    return $(a, b, c, !1)
                }

                function ba(a, b) {
                    var c;
                    return a = Ericsson.Xml.xmlEncode(a), c = ['<query i:type="a:FetchExpression" ', wa.xrm, ">", "<a:Query>", a, "</a:Query>", "</query>"].join(""), b ? ia(c, "RetrieveMultiple", u) : ja(c, "RetrieveMultiple", u)
                }

                function ca(a) {
                    return ba(a, !0)
                }

                function da(a) {
                    return ba(a, !1)
                }

                function ea(a, b, c, d) {
                    var e, f;
                    return "number" === Ericsson.type(b) && (b = new Ericsson.OrgService.OptionSetValue(b)), "number" === Ericsson.type(c) && (c = new Ericsson.OrgService.OptionSetValue(c)), e = [z("EntityMoniker", a.toXml()), z("State", b.toXml()), z("Status", c.toXml())].join(""), f = y("SetStateRequest", "SetState", e), d ? ia(f, "Execute") : ja(f, "Execute")
                }

                function fa(a, b, c) {
                    return ea(a, b, c, !0)
                }

                function ga(a, b, c) {
                    return ea(a, b, c, !1)
                }

                function ha(a, b, d, e) {
                    var f, g, h, i;
                    return c(e) && (e = !0), f = ['<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">', "<s:Body>", "<", b, ' xmlns="http://schemas.microsoft.com/xrm/2011/Contracts/Services"', ' xmlns:i="http://www.w3.org/2001/XMLSchema-instance">', a, "</", b, ">", "</s:Body>", "</s:Envelope>"].join(""), g = new XMLHttpRequest, g.open("POST", Ericsson.getClientUrl() + "/XRMServices/2011/Organization.svc/web", e), g.setRequestHeader("Accept", "application/xml, text/xml, */*"), g.setRequestHeader("Content-Type", "text/xml; charset=utf-8"), g.setRequestHeader("SOAPAction", "http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/" + b), e ? (i = Ericsson.Promise.defer(), g.onreadystatechange = function() {
                        P(g, d, i.resolve, i.reject)
                    }, g.send(f), i.promise) : (g.send(f), P(g, d, function(a) {
                        h = x(!0, a)
                    }, function(a) {
                        h = x(!1, a)
                    }), h)
                }

                function ia(a, b, c) {
                    return ha(a, b, c, !0)
                }

                function ja(a, b, c) {
                    return ha(a, b, c, !1)
                }

                function ka(a, b, c, d, e) {
                    var f = JSON.stringify(b),
                        g = d || "ericsson",
                        h = e || "webservice",
                        i = g + "_data",
                        j = g + "_error",
                        k = ["<fetch>", '<entity name="', g, "_", h, '">', '<attribute name="', g, '_data" />', '<attribute name="', g, '_error" />', "<filter>", '<condition attribute="', g, '_logicclassname" operator="eq" value="', encodeURIComponent(a), '" />', '<condition attribute="', g, '_data" operator="eq" value="', encodeURIComponent(f), '" />', '<condition attribute="', g, '_istransactional" operator="eq" value="', !!c, '" />', "</filter>", "</entity>", "</fetch>"].join("");
                    return ba(k, !0).then(function(a) {
                        if (a && a.Entities && a.Entities.length) {
                            var b = "";
                            if (!a.Entities[0][i]) throw null !== a.Entities[0][j] ? new Error(a.Entities[0][j]) : new Error('{"Error": "Unexpected response received."}');
                            return b += a.Entities[0][i], b = JSON.parse(b)
                        }
                        throw new Error('{"Error": "Unexpected response received."}')
                    })
                }

                function la(a, b, c, d, e) {
                    var f, g = "",
                        h = JSON.stringify(b),
                        i = d || "ericsson",
                        j = e || "webservice",
                        k = i + "_data",
                        l = i + "_error",
                        m = ["<fetch>", '<entity name="', i, "_", j, '">', '<attribute name="', i, '_data" />', '<attribute name="', i, '_error" />', "<filter>", '<condition attribute="', i, '_logicclassname" operator="eq" value="', encodeURIComponent(a), '" />', '<condition attribute="', i, '_data" operator="eq" value="', encodeURIComponent(h), '" />', '<condition attribute="', i, '_istransactional" operator="eq" value="', !!c, '" />', "</filter>", "</entity>", "</fetch>"].join("");
                    return f = ba(m, !1), f && f.Value && f.Value.Entities && f.Value.Entities.length ? f.Value.Entities[0][k] ? (g += f.Value.Entities[0][k], g = JSON.parse(g), x(!0, g)) : null !== f.Value.Entities[0][l] ? x(!1, new Error(f.Value.Entities[0][l])) : x(!1, new Error('{"Error": "Unexpected response received."}')) : x(!1, new Error('{"Error": "Unexpected response received."}'))
                }

                function ma() {}

                function na() {
                    return this instanceof na ? void 0 : new na
                }

                function oa(a, b) {
                    return this instanceof oa ? (this._type = Ericsson.OrgService.attributeTypes.Boolean, this.Value = a, void(this.DisplayValue = b)) : new oa(a, b)
                }

                function pa(a, b, c) {
                    return this instanceof pa ? (this._type = Ericsson.OrgService.attributeTypes.DateTime, this.Value = a, this.DisplayValue = b, void(this.UTC = c)) : new pa(a, b, c)
                }

                function qa(a, b) {
                    return this instanceof qa ? (this._type = Ericsson.OrgService.attributeTypes.Decimal, this.Value = a, void(this.DisplayValue = b)) : new qa(a, b)
                }

                function ra(a, b, c) {
                    return this instanceof ra ? (this._type = Ericsson.OrgService.attributeTypes.EntityReference, this.Id = a, this.LogicalName = b, void(this.Name = c)) : new ra(a, b, c)
                }

                function sa(a, b) {
                    return this instanceof sa ? (this._type = Ericsson.OrgService.attributeTypes.Guid, void(this.Value = a)) : new sa(a, b)
                }

                function ta(a, b) {
                    return this instanceof ta ? (this._type = Ericsson.OrgService.attributeTypes.Money, this.Value = a, void(this.DisplayValue = b)) : new ta(a, b)
                }

                function ua(a, b) {
                    return this instanceof ua ? (this._type = Ericsson.OrgService.attributeTypes.OptionSetValue, this.Value = a, void(this.Label = b)) : new ua(a, b)
                }

                function va(a) {
                    return this instanceof va ? (this._type = "ActivityPartyArray", void(this.EntityReferences = a)) : new va(a)
                }
                var wa = {
                    xrm: 'xmlns:a="http://schemas.microsoft.com/xrm/2011/Contracts"',
                    crm: 'xmlns:c="http://schemas.microsoft.com/crm/2011/Contracts"',
                    collection: 'xmlns:b="http://schemas.datacontract.org/2004/07/System.Collections.Generic"',
                    arrays: 'xmlns:b="http://schemas.microsoft.com/2003/10/Serialization/Arrays"',
                    xml: 'xmlns:c="http://www.w3.org/2001/XMLSchema"',
                    serialization: 'xmlns:c="http://schemas.microsoft.com/2003/10/Serialization/"'
                };
                return ma.prototype.toXml = function() {
                    alert("toXml() is not implemented for the object " + this._internalGetName() + ".")
                }, ma.prototype.toString = function() {
                    return "Not implemented"
                }, ma.subClass = function(a) {
                    var b;
                    b = /\W*function\s+([\w\$]+)\(/, a.prototype = new ma, a.prototype._internalGetName = function() {
                        var c;
                        return c = b.exec(a.toString()) || [], c[1] || "No Name"
                    }
                }, ma.subClass(na), na.prototype.toXml = function() {
                    return '<b:value i:nil="true" />'
                }, na.prototype.toString = function() {
                    return "null"
                }, ma.subClass(oa), oa.prototype.toXml = function() {
                    var a;
                    return a = ['<b:value i:type="c:boolean" ', wa.xml, ">", this.Value, "</b:value>"].join("")
                }, oa.prototype.toString = function() {
                    return this.DisplayValue ? this.DisplayValue : this.Value
                }, ma.subClass(pa), pa.prototype.toXml = function() {
                    var a;
                    return a = ['<b:value i:type="c:dateTime" ', wa.xml, ">", Ericsson.Date.toISOString(this.Value), "</b:value>"].join("")
                }, pa.prototype.toString = function() {
                    return this.DisplayValue ? this.DisplayValue : this.Value
                }, ma.subClass(qa), qa.prototype.toXml = function() {
                    var a;
                    return a = ['<b:value i:type="c:decimal" ', wa.xml, ">", this.Value, "</b:value>"].join("")
                }, qa.prototype.toString = function() {
                    return this.DisplayValue ? this.DisplayValue : this.Value
                }, ma.subClass(ra), ra.prototype.toXml = function() {
                    var a;
                    return a = ['<b:value i:type="a:EntityReference">', "<a:Id>" + this.Id + "</a:Id>", "<a:LogicalName>" + this.LogicalName + "</a:LogicalName>", '<a:Name i:nil="true" />', "</b:value>"].join("");
                }, ra.prototype.toString = function() {
                    return this.Name
                }, ma.subClass(sa), sa.prototype.toXml = function() {
                    var a = ['<b:value i:type="c:guid" ', wa.serialization, ">", this.Value, "</b:value>"].join("");
                    return a
                }, sa.prototype.toString = function() {
                    return this.Value
                }, ma.subClass(ta), ta.prototype.toXml = function() {
                    var a = ['<b:value i:type="a:Money">', "<a:Value>" + this.Value + "</a:Value>", "</b:value>"].join("");
                    return a
                }, ta.prototype.toString = function() {
                    return this.DisplayValue ? this.DisplayValue : this.Value
                }, ma.subClass(ua), ua.prototype.toXml = function() {
                    var a = ['<b:value i:type="a:OptionSetValue">', "<a:Value>" + this.Value + "</a:Value>", "</b:value>"].join("");
                    return a
                }, ua.prototype.toString = function() {
                    return this.Label ? this.Label : this.Value
                }, ma.subClass(va), va.prototype.toXml = function() {
                    var a, b, c = [],
                        d = 0;
                    for (d = 0; d < this.EntityReferences.length; d++) a = ["<a:Entity>", "<a:Attributes>", "<a:KeyValuePairOfstringanyType>", "<b:key>partyid</b:key>", '<b:value i:type="a:EntityReference">', "<a:Id>", this.EntityReferences[d].Id, "</a:Id>", "<a:LogicalName>", this.EntityReferences[d].LogicalName, "</a:LogicalName>", '<a:Name i:nil="true" />', "</b:value>", "</a:KeyValuePairOfstringanyType>", "</a:Attributes>", '<a:EntityState i:nil="true" />', "<a:FormattedValues />", "<a:Id>00000000-0000-0000-0000-000000000000</a:Id>", "<a:LogicalName>activityparty</a:LogicalName>", "<a:RelatedEntities />", "</a:Entity>"].join(""), c.push(a);
                    return b = ['<b:value i:type="a:ArrayOfEntity">', c.join(""), "</b:value>"].join("")
                }, va.prototype.toString = function() {
                    return ""
                }, {
                    create: V,
                    createSync: W,
                    update: Y,
                    updateSync: Z,
                    retrieve: _,
                    retrieveSync: aa,
                    retrieveMultiple: ca,
                    retrieveMultipleSync: da,
                    setState: fa,
                    setStateSync: ga,
                    execute: ia,
                    executeSync: ja,
                    executeWebService: ka,
                    executeWebServiceSync: la,
                    deleteRecord: S,
                    deleteRecordSync: T,
                    NullValue: na,
                    Boolean: oa,
                    DateTime: pa,
                    Decimal: qa,
                    EntityReference: ra,
                    Guid: sa,
                    Money: ta,
                    OptionSetValue: ua,
                    ActivityPartyArray: va,
                    executeWorkflow: K,
                    executeWorkflowSync: L,
                    initializeFromRequest: N,
                    initializeFromRequestSync: O,
                    assign: B,
                    assignSync: C,
                    associate: E,
                    associateSync: F,
                    disassociate: H,
                    disassociateSync: I
                }
            }()), Ericsson.namespace("Metadata").extend(function() {
                function a(a) {
                    var b = ["<soapenv:Envelope ", pa.soapenv, ">", "<soapenv:Body>", a, "</soapenv:Body>", "</soapenv:Envelope>"];
                    return b.join("")
                }

                function b(a, b, c, d) {
                    "undefined" === Ericsson.type(c) && (c = !0);
                    var e, f = Ericsson.getClientUrl() + oa,
                        g = new XMLHttpRequest;
                    return g.open("POST", f, c), g.setRequestHeader("Accept", "application/xml, text/xml, */*"), g.setRequestHeader("Content-Type", "text/xml; charset=utf-8"), g.setRequestHeader("SOAPAction", "http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/Execute"), c && (e = Ericsson.Promise.defer(), g.onreadystatechange = function() {
                        b(g, d, e.resolve, e.reject)
                    }), g.send(a), c ? e.promise : b(g, d)
                }

                function c(a, b) {
                    return {
                        Success: b,
                        Value: a
                    }
                }

                function d(a) {
                    if ("12029" === a.status) return new Error("The attempt to connect to the server failed.");
                    if ("12007" === a.status) return new Error("The server name could not be resolved.");
                    var b, c, d, e, f, g = Ericsson.Xml.loadXml(a.responseText),
                        h = "Unknown error (unable to parse the fault)";
                    if ("object" === Ericsson.type(g) && g.firstChild && g.firstChild.firstChild)
                        for (b = g.firstChild.firstChild, e = 0; e < b.childNodes.length; e++)
                            if (c = b.childNodes[e], "s:Fault" === c.nodeName) {
                                for (f = 0; f < c.childNodes.length; f++)
                                    if (d = c.childNodes[f], "faultstring" === d.nodeName) {
                                        h = d.text || d.textContent;
                                        break
                                    }
                                break
                            }
                    return new Error(h)
                }

                function e(a) {
                    if ("string" === Ericsson.type(a)) return a;
                    var b = "Entity";
                    return 2 & a && (b += " Attributes"), 4 & a && (b += " Privileges"), 8 & a && (b += " Relationships"), b
                }

                function f(a) {
                    if ("number" === Ericsson.type(a)) return a;
                    var b = 1;
                    return a.indexOf("Attributes") >= 0 && (b += 2), a.indexOf("Privileges") >= 0 && (b += 4), a.indexOf("Relationships") >= 0 && (b += 8), b
                }

                function g(a, b) {
                    var c, d, e, f = b,
                        g = 0,
                        h = Ericsson.Cache.get("Metadata.Entities", a.LogicalName);
                    return h && (g = h.FilterLevel, c = h.Metadata, f = b | g, d = f ^ b, 2 & d && (a.Attributes = c.Attributes), 4 & d && (a.Privileges = c.Privileges), 8 & d && (a.OneToManyRelationships = c.OneToManyRelationships, a.ManyToOneRelationships = c.ManyToOneRelationships, a.ManyToManyRelationships = c.ManyToManyRelationships)), e = {
                        FilterLevel: f,
                        Metadata: a
                    }, Ericsson.Cache.set("Metadata.Entities", a.LogicalName, e), g
                }

                function h(a) {
                    return 0 === a.childNodes.length ? null : {
                        MetadataId: Ericsson.Xml.selectSingleNode(a, "c:MetadataId").text,
                        Description: n(Ericsson.Xml.selectSingleNode(a, "c:Description")),
                        DisplayName: n(Ericsson.Xml.selectSingleNode(a, "c:DisplayName")),
                        IsCustomOptionSet: o(Ericsson.Xml.selectSingleNode(a, "c:IsCustomOptionSet")),
                        IsCustomizable: l(Ericsson.Xml.selectSingleNode(a, "c:IsCustomizable")),
                        IsGlobal: o(Ericsson.Xml.selectSingleNode(a, "c:IsGlobal")),
                        IsManaged: o(Ericsson.Xml.selectSingleNode(a, "c:IsManaged")),
                        Name: Ericsson.Xml.selectSingleNode(a, "c:Name").text,
                        OptionSetType: Ericsson.Xml.selectSingleNode(a, "c:OptionSetType").text,
                        FalseOption: {
                            MetadataId: Ericsson.Xml.selectSingleNode(a, "c:FalseOption/c:MetadataId").text,
                            Description: n(Ericsson.Xml.selectSingleNode(a, "c:FalseOption/c:Description")),
                            IsManaged: o(Ericsson.Xml.selectSingleNode(a, "c:FalseOption/c:IsManaged")),
                            Label: n(Ericsson.Xml.selectSingleNode(a, "c:FalseOption/c:Label")),
                            Value: parseInt(Ericsson.Xml.selectSingleNode(a, "c:FalseOption/c:Value").text, 10)
                        },
                        TrueOption: {
                            MetadataId: Ericsson.Xml.selectSingleNode(a, "c:TrueOption/c:MetadataId").text,
                            Description: n(Ericsson.Xml.selectSingleNode(a, "c:TrueOption/c:Description")),
                            IsManaged: o(Ericsson.Xml.selectSingleNode(a, "c:TrueOption/c:IsManaged")),
                            Label: n(Ericsson.Xml.selectSingleNode(a, "c:TrueOption/c:Label")),
                            Value: parseInt(Ericsson.Xml.selectSingleNode(a, "c:TrueOption/c:Value").text, 10)
                        }
                    }
                }

                function i(a) {
                    var b, c, d, e = [];
                    for (d = 0; d < a.childNodes.length; d++) b = a.childNodes[d], c = {
                        MetadataId: Ericsson.Xml.selectSingleNode(b, "c:MetadataId").text,
                        Description: n(Ericsson.Xml.selectSingleNode(b, "c:Description")),
                        IsManaged: o(Ericsson.Xml.selectSingleNode(b, "c:IsManaged")),
                        Label: n(Ericsson.Xml.selectSingleNode(b, "c:Label")),
                        Value: parseInt(Ericsson.Xml.selectSingleNode(b, "c:Value").text, 10),
                        State: Ericsson.Xml.selectSingleNode(b, "c:State") ? parseInt(Ericsson.Xml.selectSingleNode(b, "c:State").text, 10) : null
                    }, e.push(c);
                    return e
                }

                function j(a) {
                    return 0 === a.childNodes.length ? null : {
                        MetadataId: Ericsson.Xml.selectSingleNode(a, "c:MetadataId").text,
                        Description: n(Ericsson.Xml.selectSingleNode(a, "c:Description")),
                        DisplayName: n(Ericsson.Xml.selectSingleNode(a, "c:DisplayName")),
                        IsCustomOptionSet: o(Ericsson.Xml.selectSingleNode(a, "c:IsCustomOptionSet")),
                        IsCustomizable: l(Ericsson.Xml.selectSingleNode(a, "c:IsCustomizable")),
                        IsGlobal: o(Ericsson.Xml.selectSingleNode(a, "c:IsGlobal")),
                        IsManaged: o(Ericsson.Xml.selectSingleNode(a, "c:IsManaged")),
                        Name: Ericsson.Xml.selectSingleNode(a, "c:Name").text,
                        OptionSetType: Ericsson.Xml.selectSingleNode(a, "c:OptionSetType").text,
                        Options: i(Ericsson.Xml.selectSingleNode(a, "c:Options"))
                    }
                }

                function k(a) {
                    var b = parseInt(Ericsson.Xml.selectSingleNode(a, "c:Order").text, 10);
                    return isNaN(b) && (b = null), {
                        Behavior: Ericsson.Xml.selectSingleNode(a, "c:Behavior").text,
                        Group: Ericsson.Xml.selectSingleNode(a, "c:Group").text,
                        Label: n(Ericsson.Xml.selectSingleNode(a, "c:Label")),
                        Order: b
                    }
                }

                function l(a) {
                    return a && a.text ? {
                        CanBeChanged: "true" === Ericsson.Xml.selectSingleNode(a, "a:CanBeChanged").text ? !0 : !1,
                        ManagedPropertyLogicalName: Ericsson.Xml.selectSingleNode(a, "a:ManagedPropertyLogicalName").text,
                        Value: "true" === Ericsson.Xml.selectSingleNode(a, "a:Value").text ? !0 : !1
                    } : null
                }

                function m(a) {
                    return a && a.text ? {
                        IsManaged: "true" === Ericsson.Xml.selectSingleNode(a, "a:IsManaged").text ? !0 : !1,
                        Label: Ericsson.Xml.selectSingleNode(a, "a:Label").text,
                        LanguageCode: parseInt(Ericsson.Xml.selectSingleNode(a, "a:LanguageCode").text, 10)
                    } : null
                }

                function n(a) {
                    if (!a || !a.text) return null;
                    var b, c = Ericsson.Xml.selectSingleNode(a, "a:LocalizedLabels"),
                        d = Ericsson.Xml.selectSingleNode(a, "a:UserLocalizedLabel"),
                        e = [],
                        f = 0;
                    for (f = 0; f < c.childNodes.length; f++) b = c.childNodes[f], e.push(m(b));
                    return {
                        LocalizedLabels: e,
                        UserLocalizedLabel: d ? m(d) : null
                    }
                }

                function o(a) {
                    return a && a.text ? "true" === a.text ? !0 : !1 : null
                }

                function p(a) {
                    return a && a.text ? parseInt(a.text, 10) : null
                }

                function q(a) {
                    return a && a.text ? {
                        CanBeChanged: "true" === Ericsson.Xml.selectSingleNode(a, "a:CanBeChanged").text ? !0 : !1,
                        ManagedPropertyLogicalName: Ericsson.Xml.selectSingleNode(a, "a:ManagedPropertyLogicalName").text,
                        Value: Ericsson.Xml.selectSingleNode(a, "a:Value").text
                    } : null
                }

                function r(a) {
                    return {
                        CanBeBasic: "true" === Ericsson.Xml.selectSingleNode(a, "c:CanBeBasic").text ? !0 : !1,
                        CanBeDeep: "true" === Ericsson.Xml.selectSingleNode(a, "c:CanBeDeep").text ? !0 : !1,
                        CanBeGlobal: "true" === Ericsson.Xml.selectSingleNode(a, "c:CanBeGlobal").text ? !0 : !1,
                        CanBeLocal: "true" === Ericsson.Xml.selectSingleNode(a, "c:CanBeLocal").text ? !0 : !1,
                        Name: Ericsson.Xml.selectSingleNode(a, "c:Name").text,
                        PrivilegeId: Ericsson.Xml.selectSingleNode(a, "c:PrivilegeId").text,
                        PrivilegeType: Ericsson.Xml.selectSingleNode(a, "c:PrivilegeType").text
                    }
                }

                function s(a) {
                    return {
                        MetadataId: Ericsson.Xml.selectSingleNode(a, "c:MetadataId").text,
                        IsCustomRelationship: "true" === Ericsson.Xml.selectSingleNode(a, "c:IsCustomRelationship").text ? !0 : !1,
                        IsCustomizable: l(Ericsson.Xml.selectSingleNode(a, "c:IsCustomizable")),
                        IsManaged: "true" === Ericsson.Xml.selectSingleNode(a, "c:IsManaged").text ? !0 : !1,
                        IsValidForAdvancedFind: "true" === Ericsson.Xml.selectSingleNode(a, "c:IsValidForAdvancedFind").text ? !0 : !1,
                        SchemaName: Ericsson.Xml.selectSingleNode(a, "c:SchemaName").text,
                        SecurityTypes: Ericsson.Xml.selectSingleNode(a, "c:SecurityTypes").text,
                        AssociatedMenuConfiguration: k(Ericsson.Xml.selectSingleNode(a, "c:AssociatedMenuConfiguration")),
                        CascadeConfiguration: {
                            Assign: Ericsson.Xml.selectSingleNode(a, "c:CascadeConfiguration/c:Assign").text,
                            Delete: Ericsson.Xml.selectSingleNode(a, "c:CascadeConfiguration/c:Delete").text,
                            Merge: Ericsson.Xml.selectSingleNode(a, "c:CascadeConfiguration/c:Merge").text,
                            Reparent: Ericsson.Xml.selectSingleNode(a, "c:CascadeConfiguration/c:Reparent").text,
                            Share: Ericsson.Xml.selectSingleNode(a, "c:CascadeConfiguration/c:Share").text,
                            Unshare: Ericsson.Xml.selectSingleNode(a, "c:CascadeConfiguration/c:Unshare").text
                        },
                        ReferencedAttribute: Ericsson.Xml.selectSingleNode(a, "c:ReferencedAttribute").text,
                        ReferencedEntity: Ericsson.Xml.selectSingleNode(a, "c:ReferencedEntity").text,
                        ReferencingAttribute: Ericsson.Xml.selectSingleNode(a, "c:ReferencingAttribute").text,
                        ReferencingEntity: Ericsson.Xml.selectSingleNode(a, "c:ReferencingEntity").text
                    }
                }

                function t(a) {
                    return {
                        MetadataId: Ericsson.Xml.selectSingleNode(a, "c:MetadataId").text,
                        IsCustomRelationship: "true" === Ericsson.Xml.selectSingleNode(a, "c:IsCustomRelationship").text ? !0 : !1,
                        IsCustomizable: l(Ericsson.Xml.selectSingleNode(a, "c:IsCustomizable")),
                        IsManaged: "true" === Ericsson.Xml.selectSingleNode(a, "c:IsManaged").text ? !0 : !1,
                        IsValidForAdvancedFind: "true" === Ericsson.Xml.selectSingleNode(a, "c:IsValidForAdvancedFind").text ? !0 : !1,
                        SchemaName: Ericsson.Xml.selectSingleNode(a, "c:SchemaName").text,
                        SecurityTypes: Ericsson.Xml.selectSingleNode(a, "c:SecurityTypes").text,
                        Entity1AssociatedMenuConfiguration: k(Ericsson.Xml.selectSingleNode(a, "c:Entity1AssociatedMenuConfiguration")),
                        Entity1IntersectAttribute: Ericsson.Xml.selectSingleNode(a, "c:Entity1IntersectAttribute").text,
                        Entity1LogicalName: Ericsson.Xml.selectSingleNode(a, "c:Entity1LogicalName").text,
                        Entity2AssociatedMenuConfiguration: k(Ericsson.Xml.selectSingleNode(a, "c:Entity2AssociatedMenuConfiguration")),
                        Entity2IntersectAttribute: Ericsson.Xml.selectSingleNode(a, "c:Entity2IntersectAttribute").text,
                        Entity2LogicalName: Ericsson.Xml.selectSingleNode(a, "c:Entity2LogicalName").text,
                        IntersectEntityName: Ericsson.Xml.selectSingleNode(a, "c:IntersectEntityName").text
                    }
                }

                function u(a) {
                    var b, c, d, e, f, g, h, i, j, k, m, q, u, v, w, x, y, z, A, B = Ericsson.Xml.selectSingleNode(a, "c:Attributes"),
                        C = 0;
                    for (C = 0; C < B.childNodes.length; C++) b || (b = {}), c = B.childNodes[C], d = new S(c), b[d.LogicalName] = d;
                    for (e = Ericsson.Xml.selectSingleNode(a, "c:Privileges"), C = 0; C < e.childNodes.length; C++) g || (g = {}), f = e.childNodes[C], h = r(f), g[h.Name] = h;
                    for (i = Ericsson.Xml.selectSingleNode(a, "c:OneToManyRelationships"), C = 0; C < i.childNodes.length; C++) k || (k = {}), j = i.childNodes[C], m = s(j), k[m.SchemaName] = m;
                    for (q = Ericsson.Xml.selectSingleNode(a, "c:ManyToOneRelationships"), C = 0; C < q.childNodes.length; C++) v || (v = {}), u = q.childNodes[C], w = s(u), v[w.SchemaName] = w;
                    for (x = Ericsson.Xml.selectSingleNode(a, "c:ManyToManyRelationships"), C = 0; C < x.childNodes.length; C++) z || (z = {}), y = x.childNodes[C], A = t(y), z[A.SchemaName] = A;
                    return {
                        ActivityTypeMask: p(Ericsson.Xml.selectSingleNode(a, "c:ActivityTypeMask")),
                        Attributes: b,
                        AutoRouteToOwnerQueue: o(Ericsson.Xml.selectSingleNode(a, "c:AutoRouteToOwnerQueue")),
                        CanBeInManyToMany: l(Ericsson.Xml.selectSingleNode(a, "c:CanBeInManyToMany")),
                        CanBePrimaryEntityInRelationship: l(Ericsson.Xml.selectSingleNode(a, "c:CanBePrimaryEntityInRelationship")),
                        CanBeRelatedEntityInRelationship: l(Ericsson.Xml.selectSingleNode(a, "c:CanBeRelatedEntityInRelationship")),
                        CanCreateAttributes: l(Ericsson.Xml.selectSingleNode(a, "c:CanCreateAttributes")),
                        CanCreateCharts: l(Ericsson.Xml.selectSingleNode(a, "c:CanCreateCharts")),
                        CanCreateForms: l(Ericsson.Xml.selectSingleNode(a, "c:CanCreateForms")),
                        CanCreateViews: l(Ericsson.Xml.selectSingleNode(a, "c:CanCreateViews")),
                        CanModifyAdditionalSettings: l(Ericsson.Xml.selectSingleNode(a, "c:CanModifyAdditionalSettings")),
                        CanTriggerWorkflow: o(Ericsson.Xml.selectSingleNode(a, "c:CanTriggerWorkflow")),
                        Description: n(Ericsson.Xml.selectSingleNode(a, "c:Description")),
                        DisplayCollectionName: n(Ericsson.Xml.selectSingleNode(a, "c:DisplayCollectionName")),
                        DisplayName: n(Ericsson.Xml.selectSingleNode(a, "c:DisplayName")),
                        IconLargeName: Ericsson.Xml.selectSingleNode(a, "c:IconLargeName").text,
                        IconMediumName: Ericsson.Xml.selectSingleNode(a, "c:IconMediumName").text,
                        IconSmallName: Ericsson.Xml.selectSingleNode(a, "c:IconSmallName").text,
                        IsActivity: o(Ericsson.Xml.selectSingleNode(a, "c:IsActivity")),
                        IsActivityParty: o(Ericsson.Xml.selectSingleNode(a, "c:IsActivityParty")),
                        IsAuditEnabled: l(Ericsson.Xml.selectSingleNode(a, "c:IsAuditEnabled")),
                        IsAvailableOffline: o(Ericsson.Xml.selectSingleNode(a, "c:IsAvailableOffline")),
                        IsChildEntity: o(Ericsson.Xml.selectSingleNode(a, "c:IsChildEntity")),
                        IsConnectionsEnabled: l(Ericsson.Xml.selectSingleNode(a, "c:IsConnectionsEnabled")),
                        IsCustomEntity: o(Ericsson.Xml.selectSingleNode(a, "c:IsCustomEntity")),
                        IsCustomizable: l(Ericsson.Xml.selectSingleNode(a, "c:IsCustomizable")),
                        IsDocumentManagementEnabled: o(Ericsson.Xml.selectSingleNode(a, "c:IsDocumentManagementEnabled")),
                        IsDuplicateDetectionEnabled: l(Ericsson.Xml.selectSingleNode(a, "c:IsDuplicateDetectionEnabled")),
                        IsEnabledForCharts: o(Ericsson.Xml.selectSingleNode(a, "c:IsEnabledForCharts")),
                        IsImportable: o(Ericsson.Xml.selectSingleNode(a, "c:IsImportable")),
                        IsIntersect: o(Ericsson.Xml.selectSingleNode(a, "c:IsIntersect")),
                        IsMailMergeEnabled: l(Ericsson.Xml.selectSingleNode(a, "c:IsMailMergeEnabled")),
                        IsManaged: o(Ericsson.Xml.selectSingleNode(a, "c:IsManaged")),
                        IsMappable: l(Ericsson.Xml.selectSingleNode(a, "c:IsMappable")),
                        IsReadingPaneEnabled: o(Ericsson.Xml.selectSingleNode(a, "c:IsReadingPaneEnabled")),
                        IsRenameable: l(Ericsson.Xml.selectSingleNode(a, "c:IsRenameable")),
                        IsValidForAdvancedFind: o(Ericsson.Xml.selectSingleNode(a, "c:IsValidForAdvancedFind")),
                        IsValidForQueue: l(Ericsson.Xml.selectSingleNode(a, "c:IsValidForQueue")),
                        IsVisibleInMobile: l(Ericsson.Xml.selectSingleNode(a, "c:IsVisibleInMobile")),
                        LogicalName: Ericsson.Xml.selectSingleNode(a, "c:LogicalName").text,
                        ManyToManyRelationships: z,
                        ManyToOneRelationships: v,
                        MetadataId: Ericsson.Xml.selectSingleNode(a, "c:MetadataId").text,
                        ObjectTypeCode: p(Ericsson.Xml.selectSingleNode(a, "c:ObjectTypeCode")),
                        OneToManyRelationships: k,
                        OwnershipType: Ericsson.Xml.selectSingleNode(a, "c:OwnershipType").text,
                        PrimaryIdAttribute: Ericsson.Xml.selectSingleNode(a, "c:PrimaryIdAttribute").text,
                        PrimaryNameAttribute: Ericsson.Xml.selectSingleNode(a, "c:PrimaryNameAttribute").text,
                        Privileges: g,
                        RecurrenceBaseEntityLogicalName: Ericsson.Xml.selectSingleNode(a, "c:RecurrenceBaseEntityLogicalName").text,
                        ReportViewName: Ericsson.Xml.selectSingleNode(a, "c:ReportViewName").text,
                        SchemaName: Ericsson.Xml.selectSingleNode(a, "c:SchemaName").text,
                        toString: function() {
                            return this.LogicalName
                        }
                    }
                }

                function v(b, c) {
                    var d = ['<Execute xmlns="http://schemas.microsoft.com/xrm/2011/Contracts/Services" ', 'xmlns:i="http://www.w3.org/2001/XMLSchema-instance">', '<request i:type="a:RetrieveOptionSetRequest" ', 'xmlns:a="http://schemas.microsoft.com/xrm/2011/Contracts">', '<a:Parameters xmlns:b="http://schemas.datacontract.org/2004/07/System.Collections.Generic">', "<a:KeyValuePairOfstringanyType>", "<b:key>MetadataId</b:key>", '<b:value i:type="ser:guid" xmlns:ser="http://schemas.microsoft.com/2003/10/Serialization/">', "00000000-0000-0000-0000-000000000000", "</b:value>", "</a:KeyValuePairOfstringanyType>", "<a:KeyValuePairOfstringanyType>", "<b:key>Name</b:key>", '<b:value i:type="c:string" xmlns:c="http://www.w3.org/2001/XMLSchema">', b, "</b:value>", "</a:KeyValuePairOfstringanyType>", "<a:KeyValuePairOfstringanyType>", "<b:key>RetrieveAsIfPublished</b:key>", '<b:value i:type="c:boolean" xmlns:c="http://www.w3.org/2001/XMLSchema">', !!c, "</b:value>", "</a:KeyValuePairOfstringanyType>", "</a:Parameters>", '<a:RequestId i:nil="true" />', "<a:RequestName>RetrieveOptionSet</a:RequestName>", "</request>", "</Execute>"];
                    return a(d.join(""))
                }

                function w(a, b, c, e) {
                    var f, g;
                    4 === a.readyState && (200 === a.status ? (f = Ericsson.Xml.loadXml(a.responseText), g = new j(Ericsson.Xml.selectSingleNode(f, "//b:value")), Ericsson.Cache.set("Metadata.GlobalOptionSets", b, g), c(g)) : e(d(a))), a = null
                }

                function x(a, b) {
                    var e, f, g;
                    return 200 === a.status ? (e = Ericsson.Xml.loadXml(a.responseText), f = new j(Ericsson.Xml.selectSingleNode(e, "//b:value")), Ericsson.Cache.set("Metadata.GlobalOptionSets", b, f), a = null, c(f, !0)) : (g = d(a), a = null, c(g, !1))
                }

                function y(a, d, e) {
                    var f, g, h = Ericsson.Cache.get("Metadata.GlobalOptionSets", a);
                    return h ? e ? new Ericsson.Promise.Promise(function(a) {
                        a(h)
                    }) : c(h, !0) : (f = v(a, d), g = e ? w : x, b(f, g, e, a))
                }

                function z(a, b) {
                    return y(a, b, !0)
                }

                function A(a, b) {
                    return y(a, b, !1)
                }

                function B(a) {
                    var b = R(a);
                    return b.MaxValue = Ericsson.Xml.selectSingleNode(a, "c:MaxValue").text, b.MinValue = Ericsson.Xml.selectSingleNode(a, "c:MinValue").text, b
                }

                function C(a) {
                    var b = R(a);
                    return b.DefaultValue = o(Ericsson.Xml.selectSingleNode(a, "c:DefaultValue")), b.OptionSet = h(Ericsson.Xml.selectSingleNode(a, "c:OptionSet")), b
                }

                function D(a) {
                    var b = R(a);
                    return b.Format = Ericsson.Xml.selectSingleNode(a, "c:Format").text, b.ImeMode = Ericsson.Xml.selectSingleNode(a, "c:ImeMode").text, b
                }

                function E(a) {
                    var b = R(a);
                    return b.ImeMode = Ericsson.Xml.selectSingleNode(a, "c:ImeMode").text, b.MaxValue = Ericsson.Xml.selectSingleNode(a, "c:MaxValue").text, b.MinValue = Ericsson.Xml.selectSingleNode(a, "c:MinValue").text, b.Precision = parseInt(Ericsson.Xml.selectSingleNode(a, "c:Precision").text, 10), b
                }

                function F(a) {
                    var b = R(a);
                    return b.ImeMode = Ericsson.Xml.selectSingleNode(a, "c:ImeMode").text, b.MaxValue = Ericsson.Xml.selectSingleNode(a, "c:MaxValue").text, b.MinValue = Ericsson.Xml.selectSingleNode(a, "c:MinValue").text, b.Precision = parseInt(Ericsson.Xml.selectSingleNode(a, "c:Precision").text, 10), b
                }

                function G(a) {
                    return M(a)
                }

                function H(a) {
                    var b = R(a);
                    return b.Format = Ericsson.Xml.selectSingleNode(a, "c:Format").text, b.MaxValue = parseInt(Ericsson.Xml.selectSingleNode(a, "c:MaxValue").text, 10), b.MinValue = parseInt(Ericsson.Xml.selectSingleNode(a, "c:MinValue").text, 10), b
                }

                function I(a) {
                    var b, c, d, e, f = R(a);
                    if (f.Targets = [], b = Ericsson.Xml.selectSingleNode(a, "c:Targets"), b && b.childNodes)
                        for (c = 0, d = b.childNodes.length; d > c; c++) e = b.childNodes[c], (e.text || e.textContent) && f.Targets.push(e.text || e.textContent);
                    return f
                }

                function J(a) {
                    var b = R(a);
                    return b.ManagedPropertyLogicalName = Ericsson.Xml.selectSingleNode(a, "c:ManagedPropertyLogicalName").text, b.ParentAttributeName = Ericsson.Xml.selectSingleNode(a, "c:ParentAttributeName").text, b.ParentComponentType = p(Ericsson.Xml.selectSingleNode(a, "c:ParentComponentType")), b.ValueAttributeTypeCode = Ericsson.Xml.selectSingleNode(a, "c:ValueAttributeTypeCode").text, b
                }

                function K(a) {
                    var b = R(a);
                    return b.Format = Ericsson.Xml.selectSingleNode(a, "c:Format").text, b.ImeMode = Ericsson.Xml.selectSingleNode(a, "c:ImeMode").text, b.MaxLength = parseInt(Ericsson.Xml.selectSingleNode(a, "c:MaxLength").text, 10), b
                }

                function L(a) {
                    var b = R(a);
                    return b.CalculationOf = Ericsson.Xml.selectSingleNode(a, "c:CalculationOf").text, b.ImeMode = Ericsson.Xml.selectSingleNode(a, "c:ImeMode").text, b.MaxValue = Ericsson.Xml.selectSingleNode(a, "c:MaxValue").text, b.MinValue = Ericsson.Xml.selectSingleNode(a, "c:MinValue").text, b.Precision = parseInt(Ericsson.Xml.selectSingleNode(a, "c:Precision").text, 10), b.PrecisionSource = p(Ericsson.Xml.selectSingleNode(a, "c:PrecisionSource")), b
                }

                function M(a) {
                    var b = R(a);
                    return b.DefaultFormValue = o(Ericsson.Xml.selectSingleNode(a, "c:DefaultFormValue")), b.OptionSet = new j(Ericsson.Xml.selectSingleNode(a, "c:OptionSet")), b
                }

                function N(a) {
                    return M(a)
                }

                function O(a) {
                    return M(a)
                }

                function P(a) {
                    return M(a)
                }

                function Q(a) {
                    var b = R(a);
                    return b.Format = Ericsson.Xml.selectSingleNode(a, "c:Format").text, b.ImeMode = Ericsson.Xml.selectSingleNode(a, "c:ImeMode").text, b.MaxLength = parseInt(Ericsson.Xml.selectSingleNode(a, "c:MaxLength").text, 10), b.YomiOf = Ericsson.Xml.selectSingleNode(a, "c:YomiOf").text, b
                }

                function R(a) {
                    return {
                        AttributeOf: Ericsson.Xml.selectSingleNode(a, "c:AttributeOf").text,
                        AttributeType: Ericsson.Xml.selectSingleNode(a, "c:AttributeType").text,
                        CanBeSecuredForCreate: o(Ericsson.Xml.selectSingleNode(a, "c:CanBeSecuredForCreate")),
                        CanBeSecuredForRead: o(Ericsson.Xml.selectSingleNode(a, "c:CanBeSecuredForRead")),
                        CanBeSecuredForUpdate: o(Ericsson.Xml.selectSingleNode(a, "c:CanBeSecuredForUpdate")),
                        CanModifyAdditionalSettings: l(Ericsson.Xml.selectSingleNode(a, "c:CanModifyAdditionalSettings")),
                        ColumnNumber: p(Ericsson.Xml.selectSingleNode(a, "c:ColumnNumber")),
                        DeprecatedVersion: Ericsson.Xml.selectSingleNode(a, "c:DeprecatedVersion").text,
                        Description: n(Ericsson.Xml.selectSingleNode(a, "c:Description")),
                        DisplayName: n(Ericsson.Xml.selectSingleNode(a, "c:DisplayName")),
                        EntityLogicalName: Ericsson.Xml.selectSingleNode(a, "c:EntityLogicalName").text,
                        ExtensionData: null,
                        IsAuditEnabled: l(Ericsson.Xml.selectSingleNode(a, "c:IsAuditEnabled")),
                        IsCustomAttribute: o(Ericsson.Xml.selectSingleNode(a, "c:IsCustomAttribute")),
                        IsCustomizable: l(Ericsson.Xml.selectSingleNode(a, "c:IsCustomizable")),
                        IsManaged: o(Ericsson.Xml.selectSingleNode(a, "c:IsManaged")),
                        IsPrimaryId: o(Ericsson.Xml.selectSingleNode(a, "c:IsPrimaryId")),
                        IsPrimaryName: o(Ericsson.Xml.selectSingleNode(a, "c:IsPrimaryName")),
                        IsRenameable: l(Ericsson.Xml.selectSingleNode(a, "c:IsRenameable")),
                        IsSecured: o(Ericsson.Xml.selectSingleNode(a, "c:IsSecured")),
                        IsValidForAdvancedFind: l(Ericsson.Xml.selectSingleNode(a, "c:IsValidForAdvancedFind")),
                        IsValidForCreate: o(Ericsson.Xml.selectSingleNode(a, "c:IsValidForCreate")),
                        IsValidForRead: o(Ericsson.Xml.selectSingleNode(a, "c:IsValidForRead")),
                        IsValidForUpdate: o(Ericsson.Xml.selectSingleNode(a, "c:IsValidForUpdate")),
                        LinkedAttributeId: Ericsson.Xml.selectSingleNode(a, "c:LinkedAttributeId").text,
                        LogicalName: Ericsson.Xml.selectSingleNode(a, "c:LogicalName").text,
                        MetadataId: Ericsson.Xml.selectSingleNode(a, "c:MetadataId").text,
                        RequiredLevel: q(Ericsson.Xml.selectSingleNode(a, "c:RequiredLevel")),
                        SchemaName: Ericsson.Xml.selectSingleNode(a, "c:SchemaName").text,
                        toString: function() {
                            return this.LogicalName
                        }
                    }
                }

                function S(a) {
                    var b = Ericsson.Xml.selectSingleNode(a, "c:AttributeType").text;
                    switch (b) {
                        case "BigInt":
                            return B(a);
                        case "Boolean":
                            return C(a);
                        case "CalendarRules":
                            return I(a);
                        case "Customer":
                            return I(a);
                        case "DateTime":
                            return D(a);
                        case "Decimal":
                            return E(a);
                        case "Double":
                            return F(a);
                        case "EntityName":
                            return G(a);
                        case "Integer":
                            return H(a);
                        case "Lookup":
                            return I(a);
                        case "ManagedProperty":
                            return J(a);
                        case "Memo":
                            return K(a);
                        case "Money":
                            return L(a);
                        case "Owner":
                            return I(a);
                        case "PartyList":
                            return I(a);
                        case "Picklist":
                            return N(a);
                        case "State":
                            return O(a);
                        case "Status":
                            return P(a);
                        case "String":
                            return Q(a);
                        case "Uniqueidentifier":
                            return R(a);
                        case "Virtual":
                            return R(a);
                        default:
                            return R(a)
                    }
                }

                function T(a) {
                    return da("Entity", !1).then(function(b) {
                        var c;
                        for (c in b)
                            if (b[c].ObjectTypeCode === a) return b[c].LogicalName;
                        throw new Error('The entity with type code "' + a + '" does not exist.')
                    })
                }

                function U(a) {
                    return ga("Entity", a, !1).then(function(a) {
                        return a.ObjectTypeCode
                    })
                }

                function V(a) {
                    var b = ha(Ericsson.Metadata.entityFilters.Entity, a, !1);
                    return b && b.Success === !0 ? c(b.Value.ObjectTypeCode, !0) : b
                }

                function W(a) {
                    return ga("Entity", a, !1).then(function(a) {
                        return a.PrimaryNameAttribute
                    })
                }

                function X(a) {
                    var b = ha(Ericsson.Metadata.entityFilters.Entity, a, !1);
                    return b && b.Success === !0 ? c(b.Value.PrimaryNameAttribute, !0) : b
                }

                function Y(a, b, c) {
                    return ma(a, b, !1).then(function(a) {
                        var b = 0;
                        for (b = 0; b < a.OptionSet.Options.length; b++)
                            if (a.OptionSet.Options[b].Label.UserLocalizedLabel.Label === c) return a.OptionSet.Options[b].Value;
                        throw new Error('The option with name "' + c + '" does not exist.')
                    })
                }

                function Z(a, b, d) {
                    var e, f, g = na(a, b, !1),
                        h = !1,
                        i = 0;
                    if (!g || g.Success !== !0) return g;
                    for (f = g.Value, i = 0; i < f.OptionSet.Options.length; i++)
                        if (f.OptionSet.Options[i].Label.UserLocalizedLabel.Label === d) return c(f.OptionSet.Options[i].Value, !0);
                    return h ? void 0 : (e = new Error('The option with name "' + d + '" does not exist.'), c(e, !1))
                }

                function $(a, b, c) {
                    return ma(a, b, !1).then(function(a) {
                        var b = 0;
                        for (b = 0; b < a.OptionSet.Options.length; b++)
                            if (a.OptionSet.Options[b].Value === c) return a.OptionSet.Options[b].Label.UserLocalizedLabel.Label;
                        throw new Error('The option with value "' + c + '" does not exist.')
                    })
                }

                function _(a, b, d) {
                    var e, f, g = na(a, b, !1),
                        h = !1,
                        i = 0;
                    if (!g || g.Success !== !0) return g;
                    for (e = g.Value, i = 0; i < e.OptionSet.Options.length; i++)
                        if (e.OptionSet.Options[i].Value === d) return c(e.OptionSet.Options[i].Label.UserLocalizedLabel.Label, !0);
                    return h ? void 0 : (f = new Error('The option with value "' + d + '" does not exist.'), c(f, !1))
                }

                function aa(a, b, c, e) {
                    var f, h;
                    4 === a.readyState && (200 === a.status ? (h = Ericsson.Xml.loadXml(a.responseText), f = u(Ericsson.Xml.selectSingleNode(h, "//b:value")), g(f, b), c(f)) : e(d(a))), a = null
                }

                function ba(a, b) {
                    var e, f, h;
                    return 200 === a.status ? (f = Ericsson.Xml.loadXml(a.responseText), e = u(Ericsson.Xml.selectSingleNode(f, "//b:value")), g(e, b), a = null, c(e, !0)) : (h = d(a), a = null, c(h, !1))
                }

                function ca(a, b, c, e) {
                    if (4 === a.readyState)
                        if (200 === a.status) {
                            var f, h, i, j, k, l = {},
                                m = 0,
                                n = [];
                            for (h = Ericsson.Xml.loadXml(a.responseText), f = Ericsson.Xml.selectNodes(h, "//c:EntityMetadata"), k = 0; k < f.length; k++) i = u(f[k]), l[i.LogicalName] = i, m = 0 === k ? g(i, b) : g(i, b) & m, n.push(i.LogicalName);
                            j = b | m, Ericsson.Cache.set("Metadata.AllEntities", "FilterLevel", j), Ericsson.Cache.set("Metadata.AllEntities", "EntityList", n), c(l)
                        } else e(d(a));
                    a = null
                }

                function da(c, d) {
                    var g, h, i, j, k, l, m, n;
                    if (g = f(c), h = Ericsson.Cache.get("Metadata.AllEntities", "FilterLevel"), i = Ericsson.Cache.get("Metadata.AllEntities", "EntityList"), h && i && (h & g) === g) {
                        for (j = {}, k = 0; k < i.length; k++) j[i[k]] = Ericsson.Cache.get("Metadata.Entities", i[k]).Metadata;
                        return new Ericsson.Promise.Promise(function(a) {
                            a(j)
                        })
                    }
                    return l = g, h && (l = g | h), m = g, h && (m = l ^ h), n = ['<Execute xmlns="http://schemas.microsoft.com/xrm/2011/Contracts/Services" ', 'xmlns:i="http://www.w3.org/2001/XMLSchema-instance">', '<request i:type="a:RetrieveAllEntitiesRequest" ', 'xmlns:a="http://schemas.microsoft.com/xrm/2011/Contracts">', '<a:Parameters xmlns:b="http://schemas.datacontract.org/2004/07/System.Collections.Generic">', "<a:KeyValuePairOfstringanyType>", "<b:key>EntityFilters</b:key>", '<b:value i:type="c:EntityFilters" xmlns:c="http://schemas.microsoft.com/xrm/2011/Metadata">', e(m), "</b:value>", "</a:KeyValuePairOfstringanyType>", "<a:KeyValuePairOfstringanyType>", "<b:key>RetrieveAsIfPublished</b:key>", '<b:value i:type="c:boolean" xmlns:c="http://www.w3.org/2001/XMLSchema">', !!d, "</b:value>", "</a:KeyValuePairOfstringanyType>", "</a:Parameters>", '<a:RequestId i:nil="true" />', "<a:RequestName>RetrieveAllEntities</a:RequestName>", "</request>", "</Execute>"], n = a(n.join("")), b(n, ca, !0, g)
                }

                function ea(b, c, d) {
                    var f = ['<Execute xmlns="http://schemas.microsoft.com/xrm/2011/Contracts/Services" ', 'xmlns:i="http://www.w3.org/2001/XMLSchema-instance">', '<request i:type="a:RetrieveEntityRequest" ', 'xmlns:a="http://schemas.microsoft.com/xrm/2011/Contracts">', '<a:Parameters xmlns:b="http://schemas.datacontract.org/2004/07/System.Collections.Generic">', "<a:KeyValuePairOfstringanyType>", "<b:key>EntityFilters</b:key>", '<b:value i:type="c:EntityFilters" xmlns:c="http://schemas.microsoft.com/xrm/2011/Metadata">', e(b), "</b:value>", "</a:KeyValuePairOfstringanyType>", "<a:KeyValuePairOfstringanyType>", "<b:key>MetadataId</b:key>", '<b:value i:type="ser:guid" xmlns:ser="http://schemas.microsoft.com/2003/10/Serialization/">', "00000000-0000-0000-0000-000000000000", "</b:value>", "</a:KeyValuePairOfstringanyType>", "<a:KeyValuePairOfstringanyType>", "<b:key>RetrieveAsIfPublished</b:key>", '<b:value i:type="c:boolean" xmlns:c="http://www.w3.org/2001/XMLSchema">', !!d, "</b:value>", "</a:KeyValuePairOfstringanyType>", "<a:KeyValuePairOfstringanyType>", "<b:key>LogicalName</b:key>", '<b:value i:type="c:string" xmlns:c="http://www.w3.org/2001/XMLSchema">', c, "</b:value>", "</a:KeyValuePairOfstringanyType>", "</a:Parameters>", '<a:RequestId i:nil="true" />', "<a:RequestName>RetrieveEntity</a:RequestName>", "</request>", "</Execute>"];
                    return a(f.join(""))
                }

                function fa(a, d, e, g) {
                    var h, i, j, k, l = f(a),
                        m = Ericsson.Cache.get("Metadata.Entities", d);
                    return m && (m.FilterLevel & l) === l ? g ? new Ericsson.Promise.Promise(function(a) {
                        a(m.Metadata)
                    }) : c(m.Metadata, !0) : (h = l, m && (h = l | m.FilterLevel), i = l, m && (i = h ^ m.FilterLevel), j = ea(i, d, e), k = g ? aa : ba, b(j, k, g, i))
                }

                function ga(a, b, c) {
                    return fa(a, b, c, !0)
                }

                function ha(a, b, c) {
                    return fa(a, b, c, !1)
                }

                function ia(b, c, d) {
                    var e = ['<Execute xmlns="http://schemas.microsoft.com/xrm/2011/Contracts/Services" ', 'xmlns:i="http://www.w3.org/2001/XMLSchema-instance">', '<request i:type="a:RetrieveAttributeRequest" ', 'xmlns:a="http://schemas.microsoft.com/xrm/2011/Contracts">', '<a:Parameters xmlns:b="http://schemas.datacontract.org/2004/07/System.Collections.Generic">', "<a:KeyValuePairOfstringanyType>", "<b:key>MetadataId</b:key>", '<b:value i:type="ser:guid" xmlns:ser="http://schemas.microsoft.com/2003/10/Serialization/">', "00000000-0000-0000-0000-000000000000", "</b:value>", "</a:KeyValuePairOfstringanyType>", "<a:KeyValuePairOfstringanyType>", "<b:key>LogicalName</b:key>", '<b:value i:type="c:string" xmlns:c="http://www.w3.org/2001/XMLSchema">', c, "</b:value>", "</a:KeyValuePairOfstringanyType>", "<a:KeyValuePairOfstringanyType>", "<b:key>EntityLogicalName</b:key>", '<b:value i:type="c:string" xmlns:c="http://www.w3.org/2001/XMLSchema">', b, "</b:value>", "</a:KeyValuePairOfstringanyType>", "<a:KeyValuePairOfstringanyType>", "<b:key>RetrieveAsIfPublished</b:key>", '<b:value i:type="c:boolean" xmlns:c="http://www.w3.org/2001/XMLSchema">', !!d, "</b:value>", "</a:KeyValuePairOfstringanyType>", "</a:Parameters>", '<a:RequestId i:nil="true" />', "<a:RequestName>RetrieveAttribute</a:RequestName>", "</request>", "</Execute>"];
                    return a(e.join(""))
                }

                function ja(a, b, c, e) {
                    var f, g;
                    4 === a.readyState && (200 === a.status ? (g = Ericsson.Xml.loadXml(a.responseText), f = new S(Ericsson.Xml.selectSingleNode(g, "//b:value")), Ericsson.Cache.set("Metadata.Attributes", b, f), c(f)) : e(d(a))), a = null
                }

                function ka(a, b) {
                    var e, f, g;
                    return 200 === a.status ? (f = Ericsson.Xml.loadXml(a.responseText), e = new S(Ericsson.Xml.selectSingleNode(f, "//b:value")), Ericsson.Cache.set("Metadata.Attributes", b, e), a = null, c(e, !0)) : (g = d(a), a = null, c(g, !1))
                }

                function la(a, d, e, f) {
                    var g, h, i = a + "-" + d,
                        j = Ericsson.Cache.get("Metadata.Attributes", i);
                    return j ? f ? new Ericsson.Promise.Promise(function(a) {
                        a(j)
                    }) : c(j, !0) : (g = ia(a, d, e), h = f ? ja : ka, b(g, h, f, i))
                }

                function ma(a, b, c) {
                    return la(a, b, c, !0)
                }

                function na(a, b, c) {
                    return la(a, b, c, !1)
                }
                var oa = "/XRMServices/2011/Organization.svc/web",
                    pa = {
                        xrm: 'xmlns:a="http://schemas.microsoft.com/xrm/2011/Contracts"',
                        crm: 'xmlns:c="http://schemas.microsoft.com/crm/2011/Contracts"',
                        collection: 'xmlns:b="http://schemas.datacontract.org/2004/07/System.Collections.Generic"',
                        arrays: 'xmlns:b="http://schemas.microsoft.com/2003/10/Serialization/Arrays"',
                        xml: 'xmlns:c="http://www.w3.org/2001/XMLSchema"',
                        serialization: 'xmlns:c="http://schemas.microsoft.com/2003/10/Serialization/"',
                        soapenv: 'xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/"',
                        xmli: 'xmlns:i="http://www.w3.org/2001/XMLSchema-instance"'
                    };
                return {
                    getEntityByTypeCode: T,
                    getTypeCodeByEntity: U,
                    getTypeCodeByEntitySync: V,
                    getOptionSetOption: $,
                    getOptionSetOptionSync: _,
                    getOptionSetValue: Y,
                    getOptionSetValueSync: Z,
                    getPrimaryKeyAttribute: W,
                    getPrimaryKeyAttributeSync: X,
                    retrieveAllEntities: da,
                    retrieveAttribute: ma,
                    retrieveAttributeSync: na,
                    retrieveEntity: ga,
                    retrieveEntitySync: ha,
                    retrieveGlobalOptionSet: z,
                    retrieveGlobalOptionSetSync: A
                }
            }()), Ericsson.namespace("User").extend(function() {
                function a() {
                    var a = Array.prototype.concat.apply([], arguments);
                    return e(!1).then(function(b) {
                        return b ? f(a, b) : void 0
                    })
                }

                function b() {
                    var a = Array.prototype.concat.apply([], arguments),
                        b = e(!0);
                    return b ? f(a, b) : !1
                }

                function c() {
                    return e(!1)
                }

                function d() {
                    return e(!0)
                }

                function e(a) {
                    var b, c, d = "",
                        e = [],
                        f = i();
                    return f ? (Ericsson.each(f, function(a, b) {
                        g("Roles", Ericsson.Guid.format(b)) || (d += '<condition attribute="roleid" operator="eq" value="' + b + '" />')
                    }), b = ['<fetch mapping="logical" version="1.0">', '<entity name="role">', '<attribute name="name" />', '<attribute name="roleid" />', '<filter type="or">', d, "</filter>", "</entity>", "</fetch>"].join(""), a ? (c = Ericsson.OrgService.retrieveMultipleSync(b), Ericsson.each(c.Value.Entities, function(a, b) {
                        h("Roles", Ericsson.Guid.format(b.roleid.Value), b.name)
                    }), Ericsson.each(f, function(a, b) {
                        e.push(g("Roles", Ericsson.Guid.format(b)))
                    }), e) : Ericsson.OrgService.retrieveMultiple(b).then(function(a) {
                        return Ericsson.each(a.Entities, function(a, b) {
                            h("Roles", Ericsson.Guid.format(b.roleid.Value), b.name)
                        }), Ericsson.each(f, function(a, b) {
                            e.push(g("Roles", Ericsson.Guid.format(b)))
                        }), e
                    })) : a ? [] : Ericsson.Promise.resolve([])
                }

                function f(a, b) {
                    var c;
                    for (c = 0; c < a.length; c++)
                        if (Ericsson.Array.indexOf(b, a[c]) > -1) return !0;
                    return !1
                }

                function g(a, b) {
                    var c = Ericsson.Cache.get(p, a) || {};
                    return c[b] || null
                }

                function h(a, b, c) {
                    var d = Ericsson.Cache.get(p, a) || {};
                    d[b] = c, Ericsson.Cache.set(p, a, d)
                }

                function i() {
                    var a = null;
                    return window.Xrm && Xrm.Page && Xrm.Page.context ? a = Xrm.Page.context.getUserRoles() : window.GetGlobalContext && (a = GetGlobalContext().getUserRoles()), a ? a : void alert("Unable to determine the user's roles from Xrm.Page.context.  Please include ClientGlobalContext.js.aspx.")
                }

                function j() {
                    return n(!1)
                }

                function k() {
                    return n(!0)
                }

                function l() {
                    var a, b = Array.prototype.concat.apply([], arguments);
                    return n(!1).then(function(c) {
                        return c ? (a = [], Ericsson.each(c, function(b, c) {
                            a.push(c.name)
                        }), f(b, a)) : !1
                    })
                }

                function m() {
                    var a = Array.prototype.concat.apply([], arguments),
                        b = n(!0),
                        c = [];
                    return b ? (Ericsson.each(b, function(a, b) {
                        c.push(b.name)
                    }), f(a, c)) : !1
                }

                function n(a) {
                    var b, c, d = Ericsson.Cache.get(p, "Teams");
                    return a && d ? d.slice(0) : a ? (d = [], b = o(), c = Ericsson.OrgService.retrieveMultipleSync(b), c.Success && c.Value.Entities && 0 !== c.Value.Entities.length ? (Ericsson.each(c.Value.Entities, function(a, b) {
                        d.push({
                            name: b.name,
                            id: Ericsson.Guid.format(b.teamid.Value)
                        })
                    }), Ericsson.Cache.set(p, "Teams", d), d.slice(0)) : []) : d ? Ericsson.Promise.resolve(d.slice(0)) : (d = [], b = o(), Ericsson.OrgService.retrieveMultiple(b).then(function(a) {
                        return a.Entities && 0 !== a.Entities.length ? (Ericsson.each(a.Entities, function(a, b) {
                            d.push({
                                name: b.name,
                                id: Ericsson.Guid.format(b.teamid.Value)
                            })
                        }), Ericsson.Cache.set(p, "Teams", d), d.slice(0)) : []
                    }))
                }

                function o() {
                    return ['<fetch mapping="logical" version="1.0">', '<entity name="team">', '<attribute name="name" />', '<attribute name="teamid" />', '<link-entity name="teammembership" from="teamid" to="teamid">', "<filter>", '<condition attribute="systemuserid" operator="eq-userid" />', "</filter>", "</link-entity>", "</entity>", "</fetch>"].join("")
                }
                var p = "Ericsson.User";
                return {
                    getRoles: c,
                    getRolesSync: d,
                    hasRole: a,
                    hasRoleSync: b,
                    getTeams: j,
                    getTeamsSync: k,
                    belongsToTeam: l,
                    belongsToTeamSync: m
                }
            }()), SP && SP === Ericsson && Ericsson.Log.warn(["Deprecation warning. The 'SP' alias has been deprecated and will be removed in the next major release. ", "Please be sure to migrate existing code to use the explicit 'Ericsson' namespace."].join("")), this.Ericsson = Ericsson
    }.call(this),
    function(a) {
        a.Events = function() {
            function a(a, b) {
                var c;
                return b = Array.prototype.slice.call(arguments, 1), d._events = d._events || {}, a in d._events != !1 ? (_.each(d._events[a], function(e) {
                    return c = e.apply(d, b), _.isUndefined(c) ? void 0 : (Ericsson.Log.error(Ericsson.String.format('Error in "{0}" event: {1}', a, c)), !1)
                }), c) : void 0
            }

            function b(a, b) {
                d._events = d._events || {}, d._events[a] = d._events[a] || [], d._events[a].push(b)
            }

            function c(a, b) {
                return d._events = d._events || {}, a in d._events == !1 ? !1 : void d._events[a].splice(d._events[a].indexOf(b), 1)
            }
            var d = this;
            return _.extend(d, {
                trigger: a,
                on: b,
                off: c
            })
        }
    }(window),
    function(a) {
        a.CustomIntersectDataSource = function(a) {
            function b() {
                k.fetchAttributes = [], k.config.templateConfig && k.config.templateConfig.attributes && k.config.templateConfig.attributes.length && _.each(k.config.templateConfig.attributes, function(a, b) {
                    k.fetchAttributes.push(a)
                }), k.fetchAttributesXml = "", _.each(k.fetchAttributes, function(a, b) {
                    k.fetchAttributesXml += ['<attribute name="', a, '"/>'].join("")
                })
            }

            function c(a) {
                if (!a) throw new Error("Invalid related metadata response received");
                if (k.attribute = a.PrimaryNameAttribute, !k.attribute) throw new Error("Could not locate primary name attribute");
                k.initResult.metadata = {
                    idAttribute: a.PrimaryIdAttribute,
                    displayAttribute: a.PrimaryNameAttribute,
                    relatedLogicalName: k.config.relatedentityname
                }
            }

            function d() {
                var a = ['<fetch mapping="logical">', '<entity name="', k.config.relatedentityname, '">', '<attribute name="', k.attribute, '"/>', k.fetchAttributesXml, '<order attribute="', k.attribute, '" descending="false"/>', '<filter type="and">', '<condition attribute="statecode" operator="eq" value="0" />', "</filter>", '<link-entity name="', k.config.intersectentityname, '" ', 'to="', k.config.relatedentityname, 'id" ', 'from="', k.config.entity2attribute, '">', '<link-entity name="', k.config.entityName, '" ', 'to="', k.config.entity1attribute, '" ', 'from="', k.config.entityName, 'id">', '<filter type="and">', '<condition attribute="', k.config.entityName, 'id" operator="eq" value="', k.config.entityId, '" />', "</filter>", "</link-entity>", "</link-entity>", "</entity>", "</fetch>"].join("");
                return Ericsson.OrgService.retrieveMultiple(a)
            }

            function e() {
                var a = Ericsson.Metadata.entityFilters.Relationships;
                return k.initResult = {
                    metadata: null,
                    items: null
                }, b(), Ericsson.Metadata.retrieveEntity(a, k.config.relatedentityname, !1).then(c).then(d).then(function(a) {
                    return k.initResult.items = a.Entities, k.initResult
                })
            }

            function f(a) {
                var b = ['<fetch mapping="logical">', '<entity name="', k.config.relatedentityname, '">', '<attribute name="', k.attribute, '"/>', k.fetchAttributesXml, '<order attribute="', k.attribute, '" descending="false"/>', '<filter type="and">', '<condition attribute="statecode" operator="eq" value="0" />', "</filter>", "</entity>", "</fetch>"].join("");
                Ericsson.OrgService.retrieveMultiple(b).then(function(b) {
                    a(b.Entities)
                })
            }

            function g(a, b, c) {
                var d, e = [];
                _.each(b, function(a, b) {
                    e.push(['<condition attribute="', k.config.relatedentityname, 'id" operator="ne" value="', a, '" />'].join(""))
                }), d = ['<fetch mapping="logical" count="10">', '<entity name="', k.config.relatedentityname, '">', '<attribute name="', k.attribute, '"/>', k.fetchAttributesXml, '<order attribute="', k.attribute, '" descending="false"/>', '<filter type="and">', '<condition attribute="statecode" operator="eq" value="0" />', '<condition attribute="', k.attribute, '" operator="like" value="%', Ericsson.Xml.xmlEncode(a), '%" />', e, "</filter>", "</entity>", "</fetch>"].join(""), Ericsson.OrgService.retrieveMultiple(d).then(function(a) {
                    c(a.Entities)
                })
            }

            function h(a) {
                var b = {};
                return k.trigger("busy", !0), b[k.config.entity1attribute] = new Ericsson.OrgService.EntityReference(k.config.entityId, k.config.entityName), b[k.config.entity2attribute] = new Ericsson.OrgService.EntityReference(a, k.config.relatedentityname), Ericsson.OrgService.create(k.config.intersectentityname, b)["catch"](function(a) {
                    alert("An error was encountered while saving changes."), Ericsson.Log.log(a && a.message ? a.message : JSON.stringify(a))
                })["finally"](function() {
                    k.trigger("busy", !1), k.trigger("add")
                })
            }

            function i(a) {
                var b = ['<fetch mapping="logical">', '<entity name="', k.config.intersectentityname, '">', '<attribute name="', k.config.entity2attribute, '"/>', '<filter type="and">', '<condition attribute="statecode" operator="eq" value="0" />', '<condition attribute="', k.config.entity2attribute, '" operator="eq" value="', a, '" />', "</filter>", "</entity>", "</fetch>"].join("");
                return Ericsson.OrgService.retrieveMultiple(b).then(function(a) {
                    if (a && a.Entities && 1 == a.Entities.length) return a.Entities[0].Metadata.Id;
                    throw new Error("Invalid response received while locating intersect record.")
                })
            }

            function j(a) {
                return k.trigger("busy", !0), i(a).then(function(a) {
                    return Ericsson.OrgService.deleteRecord(k.config.intersectentityname, a)
                })["catch"](function(a) {
                    alert("An error was encountered while saving changes."), Ericsson.Log.log(a && a.message ? a.message : JSON.stringify(a))
                })["finally"](function() {
                    k.trigger("busy", !1)
                })
            }
            var k = this;
            return k.config = a, _.extend(k, {
                init: e,
                retrieveAllOptions: f,
                search: g,
                add: h,
                remove: j,
                getIntersectId: i
            }, new Events)
        }
    }(window),
    function(a) {
        a.ManyToManyDataSource = function(a) {
            function b() {
                k.fetchAttributes = [], k.config.templateConfig && k.config.templateConfig.attributes && k.config.templateConfig.attributes.length && _.each(k.config.templateConfig.attributes, function(a, b) {
                    k.fetchAttributes.push(a)
                }), k.fetchAttributesXml = "", _.each(k.fetchAttributes, function(a, b) {
                    k.fetchAttributesXml += ['<attribute name="', a, '"/>'].join("")
                })
            }

            function c(a) {
                var b = Ericsson.Metadata.entityFilters.Entity,
                    c = {};
                if (!a || !a.ManyToManyRelationships) throw new Error("Invalid metadata response received");
                if (k.relationship = a.ManyToManyRelationships[k.config.manytomanyrelationship], !k.relationship) throw new Error("Could not locate relationship with name: " + k.config.manytomanyrelationship);
                return k.relationship.Entity2LogicalName == k.config.entityName && (c.Entity2LogicalName = k.relationship.Entity1LogicalName, c.Entity1LogicalName = k.relationship.Entity2LogicalName, k.relationship.Entity1LogicalName = c.Entity1LogicalName, k.relationship.Entity2LogicalName = c.Entity2LogicalName), Ericsson.Metadata.retrieveEntity(b, k.relationship.Entity2LogicalName, !1)
            }

            function d(a) {
                if (!a) throw new Error("Invalid related metadata response received");
                if (k.attribute = a.PrimaryNameAttribute, !k.attribute) throw new Error("Could not locate primary name attribute");
                k.initResult.metadata = {
                    idAttribute: a.PrimaryIdAttribute,
                    displayAttribute: a.PrimaryNameAttribute,
                    relatedLogicalName: k.relationship.Entity2LogicalName
                }
            }

            function e() {
                var a = ['<fetch mapping="logical">', '<entity name="', k.relationship.Entity2LogicalName, '">', '<attribute name="', k.attribute, '"/>', k.fetchAttributesXml, '<order attribute="', k.attribute, '" descending="false"/>', '<filter type="and">', '<condition attribute="statecode" operator="eq" value="0" />', "</filter>", '<link-entity name="', k.relationship.IntersectEntityName, '" ', 'from="', k.relationship.Entity2LogicalName, 'id" ', 'to="', k.relationship.Entity2LogicalName, 'id">', '<link-entity name="', k.relationship.Entity1LogicalName, '" ', 'from="', k.relationship.Entity1LogicalName, 'id" ', 'to="', k.relationship.Entity1LogicalName, 'id">', '<filter type="and">', '<condition attribute="', k.relationship.Entity1LogicalName, 'id" operator="eq" value="', k.config.entityId, '" />', "</filter>", "</link-entity>", "</link-entity>", "</entity>", "</fetch>"].join("");
                return Ericsson.OrgService.retrieveMultiple(a)
            }

            function f() {
                var a = Ericsson.Metadata.entityFilters.Relationships,
                    f = k.config.entityName;
                return k.initResult = {
                    metadata: null,
                    items: null
                }, b(), Ericsson.Metadata.retrieveEntity(a, f, !1).then(c).then(d).then(e).then(function(a) {
                    return k.initResult.items = a.Entities, k.initResult
                })
            }

            function g(a) {
                var b = ['<fetch mapping="logical">', '<entity name="', k.relationship.Entity2LogicalName, '">', '<attribute name="', k.attribute, '"/>', k.fetchAttributesXml, '<order attribute="', k.attribute, '" descending="false"/>', '<filter type="and">', '<condition attribute="statecode" operator="eq" value="0" />', "</filter>", "</entity>", "</fetch>"].join("");
                Ericsson.OrgService.retrieveMultiple(b).then(function(b) {
                    a(b.Entities)
                })
            }

            function h(a, b, c) {
                var d, e = [];
                _.each(b, function(a, b) {
                    e.push(['<condition attribute="', k.relationship.Entity2LogicalName, 'id" operator="ne" value="', a, '" />'].join(""))
                }), d = ['<fetch mapping="logical" count="10">', '<entity name="', k.relationship.Entity2LogicalName, '">', '<attribute name="', k.attribute, '"/>', k.fetchAttributesXml, '<order attribute="', k.attribute, '" descending="false"/>', '<filter type="and">', '<condition attribute="statecode" operator="eq" value="0" />', '<condition attribute="', k.attribute, '" operator="like" value="%', Ericsson.Xml.xmlEncode(a), '%" />', e.join(""), "</filter>", "</entity>", "</fetch>"].join(""), Ericsson.OrgService.retrieveMultiple(d).then(function(a) {
                    c(a.Entities)
                })
            }

            function i(a) {
                var b, c;
                return k.trigger("busy", !0), b = new Ericsson.OrgService.EntityReference(k.config.entityId, k.config.entityName), c = new Ericsson.OrgService.EntityReference(a, k.relationship.Entity2LogicalName), Ericsson.OrgService.associate(b, [c], k.config.manytomanyrelationship)["catch"](function(a) {
                    alert("An error was encountered while saving changes."), Ericsson.Log.log(a && a.message ? a.message : JSON.stringify(a))
                })["finally"](function() {
                    k.trigger("busy", !1), k.trigger("add")
                })
            }

            function j(a) {
                var b, c;
                return k.trigger("busy", !0), b = new Ericsson.OrgService.EntityReference(k.config.entityId, k.config.entityName), c = new Ericsson.OrgService.EntityReference(a, k.relationship.Entity2LogicalName), Ericsson.OrgService.disassociate(b, [c], k.config.manytomanyrelationship)["catch"](function(a) {
                    alert("An error was encountered while saving changes."), Ericsson.Log.log(a && a.message ? a.message : JSON.stringify(a))
                })["finally"](function() {
                    k.trigger("busy", !1)
                })
            }
            var k = this;
            return k.config = a, _.extend(k, {
                init: f,
                retrieveAllOptions: g,
                search: h,
                add: i,
                remove: j
            }, new Events)
        }
    }(window),
    function(a) {
        a.OptionSetDataSource = function(a) {
            function b(a) {
                var b = new RegExp(h.config.separator, "g");
                return a.replace(b, "")
            }

            function c() {
                var a, c = {
                    metadata: {
                        idAttribute: "Value",
                        displayAttribute: "Label"
                    },
                    items: []
                };
                return h.config.separator || (h.config.separator = ","), h.config.labelseparator || (h.config.labelseparator = ", "), Ericsson.Metadata.retrieveGlobalOptionSet(h.config.optionset).then(function(d) {
                    if (!d || !d.Options) throw new Error("Invalid metadata response received");
                    return h.attribute = h.config.Xrm.Page.getAttribute(h.config.attribute), h.labelAttribute = null != h.config.labelattribute ? h.config.Xrm.Page.getAttribute(h.config.labelattribute) : null, h.optionset = d, h.options = [], h.optionHash = {}, _.each(h.optionset.Options, function(a, c) {
                        h.options.push({
                            Label: b(a.Label.UserLocalizedLabel.Label),
                            Value: a.Value
                        }), h.optionHash[a.Value] = b(a.Label.UserLocalizedLabel.Label)
                            //h.options = _.sortBy(h.options, "Label")
                    }), a = h.attribute.getValue(), null != a && a.length && (a = a.split(h.config.separator), _.each(a, function(a, b) {
                        c.items.push({
                            Label: h.optionHash[parseInt(a, 10)],
                            Value: parseInt(a, 10)
                        })
                    }), c.items = _.sortBy(c.items, "Label")), c
                })
            }

            function d(a) {
                a(h.options)
            }

            function e(a, b, c) {
                var d = [],
                    e = new RegExp(a, "i");
                _.each(h.options, function(a, c) {
                    e.test(a.Label) && b.indexOf(a.Value.toString()) < 0 && d.push(a)
                }), c(_.sortBy(d, "Label"))
            }

            function f(a) {
                var b, c;
                h.trigger("busy", !0), b = h.attribute.getValue(), null == b && (b = ""), b.length > 0 ? b = b + h.config.separator + a : b += a, h.attribute.setValue(b), null != h.labelAttribute && (c = h.labelAttribute.getValue(), null == c && (c = ""), c = c.length > 0 ? c + h.config.labelseparator + h.optionHash[parseInt(a, 10)] : h.optionHash[parseInt(a, 10)], h.labelAttribute.setValue(c)), h.trigger("busy", !1), h.trigger("add")
            }

            function g(a) {
                var b, c = [],
                    d = [];
                h.trigger("busy", !0), b = h.attribute.getValue().split(h.config.separator), _.each(b, function(b, d) {
                    a != b && c.push(b)
                }), c.length ? h.attribute.setValue(c.join(h.config.separator)) : h.attribute.setValue(null), null != h.labelAttribute && (c.length ? (_.each(c, function(a, b) {
                    d.push(h.optionHash[parseInt(a, 10)])
                }), h.labelAttribute.setValue(d.join(h.config.labelseparator))) : h.labelAttribute.setValue(null)), h.trigger("busy", !1)
            }
            var h = this;
            return h.config = a, _.extend(h, {
                init: c,
                retrieveAllOptions: d,
                search: e,
                add: f,
                remove: g
            }, new Events)
        }
    }(window),
    function(a) {
        a.Ericsson = a.Ericsson || {}, a.Ericsson.Controls = a.Ericsson.Controls || {}, a.Ericsson.Controls.Checklist = function(a, b) {
            function c(a, c) {
                return a.title = a[b.labelField], a && a.Metadata && a.Metadata.LogicalName && (a.iconUrl = [b.serverUrl, "/_Common/icon.aspx?etn=", a.Metadata.LogicalName, "&iconType=Ribbon16&cache=1"].join("")), t(a)
            }

            function d(a) {
                var b, c = $(this),
                    d = c.val(),
                    e = new RegExp(d, "i");
                m.find('[data-hook~="option"]').each(function() {
                    b = $(this), e.test(b.data("label")) ? b.removeClass("multiselect-option-non-match") : b.addClass("multiselect-option-non-match")
                })
            }

            function e(a) {
                var b = $(this);
                switch (n.find('[data-hook~="search"]').val(null), m.find('[data-hook~="option"]').removeClass("multiselect-option-non-match"), $("[data-view]").removeClass("selected"), b.addClass("selected"), o = q[b.data("view")]) {
                    case q.all:
                        m.find('[data-hook~="option"]').removeClass("multiselect-option-hidden");
                        break;
                    case q.selected:
                        m.find('[data-hook~="option"]:not(.multiselect-option-selected)').addClass("multiselect-option-hidden")
                }
            }

            function f(a, c) {
                window.open([b.serverUrl, "/main.aspx?etn=", a, "&id=", c, "&pagetype=entityrecord"].join(""), "_blank")
            }

            function g(a) {
                var c, d = $(this);
                if (b.relatedLogicalName) return p ? void a.preventDefault() : void(d.is(".multiselect-option-selected") && (c = d.data("value"), b.openIntersect && b.dataSource instanceof CustomIntersectDataSource ? b.dataSource.getIntersectId(c).then(function(a) {
                    f(b.intersectEntityName, a)
                })["catch"](function(a) {
                    alert("Failed to locate intersect. Could not open record."), Ericsson.Log.log(a && a.message ? a.message : JSON.stringify(a))
                }) : f(b.relatedLogicalName, c)))
            }

            function h(a) {
                var c = $(this).parent();
                if (!b.isDisabled) {
                    if (p) return void a.preventDefault();
                    c.toggleClass("multiselect-option-selected"), c.is(".multiselect-option-selected") ? (b.dataSource.add(c.data("value")), c.find('input[type="checkbox"]').attr("checked", !0)) : (b.dataSource.remove(c.data("value")), c.toggleClass("multiselect-option-hidden", o == q.selected), c.find('input[type="checkbox"]').attr("checked", !1))
                }
            }

            function i(a) {
                p = a, n.toggleClass("loading", a)
            }

            function j() {
                var a, d, e = Ericsson.Promise.defer();
                return b.dataSource.retrieveAllOptions(function(f) {
                    try {
                        m.empty(), _.each(f, function(e) {
                            a = $(s()), d = $(c(e)), a.find('[data-hook~="content"]').empty().append(d), a.data("option", e), a.attr("data-value", e[b.valueField]), a.attr("data-label", e[b.labelField]), m.append(a)
                        }), _.each(b.initialValue, function(a) {
                            $(['[data-value~="', a[b.valueField], '"]'].join("")).addClass("multiselect-option-selected").find('input[type="checkbox"]').attr("checked", !0)
                        }), e.resolve(!0)
                    } catch (g) {
                        e.reject(g)
                    }
                }), e.promise
            }

            function k() {
                n.find('[data-hook~="search"]').on("keyup", d), n.find('[data-hook~="switch-view"]').on("click", e), m.on("click", '[data-hook~="option-toggle"]', h), m.on("dblclick", '[data-hook~="option"]', g), b.dataSource.on("busy", i)
            }

            function l() {
                return n = $(a).html(r()).addClass("multiselect").attr("data-hook", "container").css("visibility", "hidden"), m = $('[data-hook~="checklist"]'), k(), b.doDisplayCreateFirst ? (n.html(['<span style="font-size: 12px; color: #8b8b8b;">', "To enable this content, please first save this record.", "</span>"].join("")), void n.css("visibility", "visible")) : (b.optionTemplate && (t = b.optionTemplate), void j().then(function() {
                    b.setMaxHeight && (m.css("max-height", b.setMaxHeight(n)), $(window).on("resize", function() {
                        m.css("max-height", b.setMaxHeight(n))
                    })), b.isDisabled && (n.addClass("disabled"), m.find('input[type="checkbox"]').attr("disabled", !0)), n.css("visibility", "visible")
                })["catch"](function(a) {
                    alert(a)
                }))
            }
            var m, n, o, p, q = {
                    all: 0,
                    selected: 1
                },
                //r = _.template(['<nav data-hook="nav" class="views-container">', '<ul class="views">', '<li class="view selected" data-hook="switch-view" data-view="all">All</li>', '<li class="view" data-hook="switch-view" data-view="selected">Selected</li>', '<li class="search">', '<input type="text" placeholder="Search..." class="search-input" data-hook="search" />', "</li>", "</ul>", "</nav>", '<ul class="multiselect" data-hook="checklist"></ul>'].join("")),
				//r = _.template(['<nav data-hook="nav" class="views-container">', '<ul class="views">', '<li class="view selected" data-hook="switch-view" data-view="all"></li>', '<li class="view" data-hook="switch-view" data-view="selected"></li>', '<li class="search" style="width:92.5%;">', '<input type="text" placeholder="Search..." class="search-input" data-hook="search" style="width:92.8%;height:8px"/>', "</li>", "</ul>", "</nav>", '<ul class="multiselect" data-hook="checklist"></ul>'].join("")),
                r = _.template(['<div style="width: 30%; float: left; display: block;"><label>' + translationMultiSelect.GetData().tAddressUsage + '</label><img src="/_imgs/frm_required.gif?ver=1130869477"></div><div style="width: 70%; float: left; display: block;"><ul class="multiselect" style="padding-left: 6%; max-height: 192px;" data-hook="checklist"></ul></div>'].join("")),
                s = _.template(['<li class="multiselect-option" data-hook="option">', '<div class="multiselect-option-toggle" data-hook="option-toggle">', '<input type="checkbox" />', "</div>", '<div class="multiselect-option-content" data-hook="content"></div>', "</li>"].join("")),
                t = _.template(["<div>", '<span class="title">', '<span class="name">', '<% if (typeof iconUrl !== "undefined") { %>', '<i class="icon" style="background-image: url(<%= iconUrl %>);"></i>', "<% } %>", '<span class="name-value"><%= title %></span>', "</span>", "</span>", "</div>"].join(""));
            return l(), _.extend(self, new Events)
        }
    }(window),
    function(a) {
        function b(a) {
            return $(window).height() - a.find('[data-hook~="nav"]').outerHeight()
        }

        function c() {
            parent.Xrm.Page.data.removeOnLoad(c), document.location.reload(!0)
        }

        function d(a) {
            var c, d, e = parent.Xrm.Page.ui.getFormType(),
                f = !1,
                g = !1;
            if (_.defaults(a, {
                    entityId: parent.Xrm.Page.data.entity.getId(),
                    entityName: parent.Xrm.Page.data.entity.getEntityName()
                }), a.Xrm = parent.Xrm, null != a.manytomanyrelationship) c = new ManyToManyDataSource(a), f = 2 == e, g = 1 == e;
            else if (null != a.optionset && null != a.attribute) c = new OptionSetDataSource(a), f = 1 == e || 2 == e;
            else {
                if (null == a.intersectentityname || null == a.relatedentityname || null == a.entity1attribute || null == a.entity2attribute) throw new Error("Could not find a valid datasource from supplied parameters.");
                c = new CustomIntersectDataSource(a), f = 2 == e, g = 1 == e
            }
            return d = {
                doDisplayCreateFirst: g,
                isDisabled: 1 != a.disabled && f ? !1 : !0,
                dataSource: c,
                openIntersect: a.openintersect,
                intersectEntityName: a.intersectentityname,
                optionTemplate: a.optionTemplate,
                setMaxHeight: b,
                serverUrl: parent.Xrm.Page.context.getClientUrl()
            }, c.init().then(function(a) {
                return d.valueField = a.metadata.idAttribute, d.labelField = a.metadata.displayAttribute, d.relatedLogicalName = a.metadata.relatedLogicalName, d.initialValue = a.items, d
            })
        }

        function e(a) {
            var b, c = Ericsson.Promise.defer();
            return a.template ? $.get([parent.Xrm.Page.context.getClientUrl(), "/WebResources/", a.template].join("")).done(function(d) {
                b = d.split("\n"), a.templateConfig = JSON.parse(b.shift()), a.optionTemplate = _.template(b.join("\n")), c.resolve(a)
            }).fail(function() {
                c.reject.apply(c, arguments)
            }) : c.resolve(a), c.promise
        }

        function f() {
            var a = Ericsson.Promise.defer(),
                b = Ericsson.getQueryStringParams().data;
            return null == b ? (a.reject("Invalid configuration specified for multiselect frame with id: " + window.frameElement != null ? window.frameElement.id : "[unknown]"), a) : (a.resolve(b), a.promise)
        }

        function g() {
            var a;
            parent.Xrm.Page.data.addOnLoad && parent.Xrm.Page.data.addOnLoad(c), f().then(e).then(d).then(function(b) {
                a = new Ericsson.Controls.Checklist("#multiselect", b)
            })["catch"](function(a) {
                alert(a)
            })
        }
        $(g)
    }(window);