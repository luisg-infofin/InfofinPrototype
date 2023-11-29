#################
# Build the app #
#################
FROM node:20-alpine as build
WORKDIR /app/ClientApps/angular_app
COPY ClientApps/angular_app/package.json ClientApps/angular_app/package-lock.json ./
RUN npm install
COPY ClientApps/angular_app .
RUN npm install -g @angular/cli
RUN ng build --configuration production --output-path=/dist

################
# Run in NGINX #
################
FROM nginx:alpine
COPY --from=build /app/ClientApps/angular_app/dist/browser /usr/share/nginx/html
COPY --from=build /app/ClientApps/angular_app/default.conf /etc/nginx/conf.d/default.conf

# When the container starts, replace the env.js with values from environment variables
CMD ["/bin/sh",  "-c",  "envsubst < /usr/share/nginx/html/assets/env.template.js > /usr/share/nginx/html/assets/env.js && exec nginx -g 'daemon off;'"]