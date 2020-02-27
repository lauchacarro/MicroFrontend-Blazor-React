console.info("run builder.js")
const { promisify } = require('util');
const fs = require('fs');
const rimraf = require('rimraf');
const ncp = require('ncp').ncp;

const fsAsync = ['exists', 'mkdir']
  .reduce((value, func) => Object.assign(value, { [func]: promisify(fs[func]) }), {});
const rimrafAsync = promisify(rimraf);
const ncpAsync = promisify(ncp);
const buildDir = `${__dirname}/build`;

const run = async () => {

  await rimrafAsync(buildDir)
  await fsAsync.mkdir(buildDir);

  let publishDir = `${__dirname}/src/blazor/BlazorCompiler/bin/Release/netstandard2.0/publish/BlazorCompiler/dist`;
  await ncpAsync(`${publishDir}`, `${buildDir}`);

  publishDir = `${__dirname}/src/react/build`;
  await ncpAsync(`${publishDir}`, `${buildDir}`);

  publishDir = `${__dirname}/src/public`;
  await ncpAsync(`${publishDir}`, `${buildDir}`);

};

run();