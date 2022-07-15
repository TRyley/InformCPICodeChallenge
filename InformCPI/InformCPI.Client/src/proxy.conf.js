const PROXY_CONFIG = [
  {
    context: [
      "/Contacts",
    ],
    target: "http://localhost:5000",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
