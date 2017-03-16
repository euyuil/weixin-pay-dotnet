# Weixin (WeChat) Pay SDK for .NET Standard

Development is in progress.

## Key usage

Please read the payment workflow first: https://pay.weixin.qq.com/wiki/doc/api/app/app.php?chapter=8_3.

### Unified order

In your ASP.NET API controller, you can add an action like the following:

    public async Task<IHttpActionResult> UnifiedOrderDemo()
    {
        var client = new WeixinPayClient("appId", "merchantId", "notifyUrl");
        var prepayId = await client.UnifiedOrderAsync(
            "RA2-20170316232905-28732413", "WarFactory-ApocalypseTank", 1750, GetClientIp());

        return Ok(prepayId);
    }

The action above creates a unified order on Weixin side, and it passes the pre-pay ID of the order to the mobile App.

### Result notify

TODO.

### Order query

TODO.

## NuGet

TODO.

## License

MIT.
