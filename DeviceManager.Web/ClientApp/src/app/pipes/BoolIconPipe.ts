import { PipeTransform, Pipe } from "@angular/core";
import { faCheck, faTimes } from "@fortawesome/free-solid-svg-icons";

@Pipe({ name: 'boolIcon' })
export class BoolIconPipe implements PipeTransform {

  transform(value: any, ...args: any[]) {

    var icon = null;

    if (value == true) {
      icon = faCheck;
    } else {
      icon = faTimes;
    }

    return '<b>Tst</b>';
  }

}
