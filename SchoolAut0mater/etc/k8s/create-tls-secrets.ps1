mkcert `
"schoolaut0mater-st-angular" `
"schoolaut0mater-st-public-web" "schoolaut0mater-st-authserver" `
"schoolaut0mater-st-gateway-web" "schoolaut0mater-st-gateway-web-public" `
"schoolaut0mater-st-identity" "schoolaut0mater-st-administration" "schoolaut0mater-st-saas" "schoolaut0mater-st-product" 
kubectl create namespace schoolaut0mater
kubectl create secret tls -n schoolaut0mater schoolaut0mater-tls --cert=./schoolaut0mater-st-web+10.pem  --key=./schoolaut0mater-st-web+10-key.pem