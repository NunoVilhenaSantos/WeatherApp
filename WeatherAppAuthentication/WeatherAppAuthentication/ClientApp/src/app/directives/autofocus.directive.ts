// ---------------------------------------------------
// Demo 1: https://quickapp-pro.azurewebsites.net
// Demo 2: https://quickapp-standard.azurewebsites.net
//
// --> Gun4Hire: contact@ebenmonney.com
// ---------------------------------------------------

import { Directive, ElementRef, OnInit } from '@angular/core';


@Directive({
  selector: '[appAutofocus]'
})
export class AutofocusDirective implements OnInit {
  constructor(public elementRef: ElementRef) { }

  ngOnInit() {
    setTimeout(() => this.elementRef.nativeElement.focus(), 500);
  }
}
