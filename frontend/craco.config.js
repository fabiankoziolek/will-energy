/* eslint-disable @typescript-eslint/no-var-requires */
module.exports = {
  style: {
    postcss: {
      plugins: [
        require('postcss-media-variables'),
        require('postcss-mixins')({
          mixinsDir: 'src/static/mixins',
        }),
        require('postcss-simple-vars'),
        require('postcss-custom-media')({
          preserve: false,
          importFrom: 'src/static/styles/media.css',
        }),
        require('postcss-custom-properties')({
          preserve: false,
          importFrom: 'src/static/styles/variables.css',
        }),
        require('postcss-calc'),
        require('postcss-media-variables'),
        require('postcss-color-function'),
        require('postcss-pxtorem')({
          rootValue: 16,
          unitPrecision: 5,
          propList: ['font', 'font-size', 'line-height', 'letter-spacing', 'border-radius'],
          selectorBlackList: ['body'],
          replace: true,
        }),
        require('postcss-inline-svg')({
          path: 'src/static/images',
        }),
        require('postcss-svgo'),
        require('postcss-nested'),
        require('postcss-normalize'),
        require('postcss-nesting'),
        require('autoprefixer'),
      ],
    },
  },
};
