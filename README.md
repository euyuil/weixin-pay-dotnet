# WeChat Pay SDK for .NET Standard

Development is in progress.

## Key usage

Please read the payment workflow first: https://pay.weixin.qq.com/wiki/doc/api/app/app.php?chapter=8_3.

### Unified order

    var client = new WeixinPayClient(...);
    var response = await client.UnifiedOrderAsync("Apocalypse Tank", 1750, 30);
    return Ok(new { response.PrePayId });

### Result notify

TODO.

### Order query

TODO.

## NuGet

TODO.

## License

MIT.
