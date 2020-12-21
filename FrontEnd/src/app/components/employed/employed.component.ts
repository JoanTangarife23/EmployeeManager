import {Component} from '@angular/core';

@Component({
    selector: 'employed',
    templateUrl: './employed.component.html',
    styleUrls: ['./employed.component.css']
})
export class Employed{
    constructor(){
        console.log("Componente cargado");
    }
}