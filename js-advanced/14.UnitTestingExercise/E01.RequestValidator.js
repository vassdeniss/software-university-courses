function validate(request) {
  const allowedMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];
  if (
    request.method === undefined ||
    !allowedMethods.includes(request.method)
  ) {
    throw new Error('Invalid request header: Invalid Method');
  }

  if (
    request.uri === undefined ||
    !request.uri ||
    !request.uri.match(/^([a-zA-Z0-9\.]+|\*)$/g)
  ) {
    throw new Error('Invalid request header: Invalid URI');
  }

  const allowedVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
  if (
    request.version === undefined ||
    !allowedVersions.includes(request.version)
  ) {
    throw new Error('Invalid request header: Invalid Version');
  }

  if (
    request.message === undefined ||
    !request.message.match(/^[^<>&\'\"\\]*$/g)
  ) {
    throw new Error('Invalid request header: Invalid Message');
  }

  return request;
}

console.log(
  validate({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: '',
  })
);

console.log(
  validate({
    method: 'OPTIONS',
    uri: 'git.master',
    version: 'HTTP/1.1',
    message: '-recursive',
  })
);

console.log(
  validate({
    method: 'POST',
    uri: 'home.bash',
    message: 'rm -rf /*',
  })
);
