
*** 文件的伺服
# 传统ASP.NET
根目录的文件都被伺服
某些重要文件不会被伺服
黑名单策略
# ASP.NET CORE
只有wwwroot被伺服
白名单策略

*** 依赖注入，IOC容器
服务生命周期
Transient：每次被请求都会创建新的实例
Scoped：每次web请求会创建一个实例
Singleton：一旦被创建实例，就会一直使用这个实例，直到应用停止

*** 依赖注入的好处
不用管生命周期（容器来管）
类型之间没有依赖

*** 包的安装
服务端 Nuget
客户端	Npm
前端工具
Npm: package.json
Bundel和minify：bundleConfig.json
BuildBundlerMinifier
Task Runners:Guop,Grunt,Webpack

*** MVC
Controller
Action
Filter
Model Binding
Routing
Attibute

*** View Component
相当于partial view
