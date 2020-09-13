import { Component, Input } from "@angular/core";

@Component({
  selector: 'x-tooltip',
  template: '<div>{{ text }}</div>',
  styles: [
    "div { padding: 5px 15px; background: rgba(0, 0, 0, 0.6); color: white; border: 1px solid rgba(0, 0, 0, 0.6); border-radius: 5px; }"
  ]
})
export class TooltipComponent {

  @Input() text: string = '';



}
