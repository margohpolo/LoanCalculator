// const { env } = require('process');

// const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
//     env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'https://localhost:7247';

// const PROXY_CONFIG = [
//   {
//     context: [
//       "/weatherforecast",
//     ],
//     target,
//     secure: false,
//     logLevel: "debug",
//     changeOrigin: true
//   }
// ]

// module.exports = PROXY_CONFIG;



module.exports = {
  '/api': {
    target: process.env['services__calculatorapi__1'],
    pathRewrite: {
      '^/api': '',
    },
    secure: false,
    logLevel: "debug",
    changeOrigin: "true"
  }
};
